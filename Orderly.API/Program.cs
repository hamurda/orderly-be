using Orderly.Infrastructure.Extensions;
using Orderly.Application.Extensions;
using Serilog;
using Orderly.API.Middlewares;
using Orderly.Domain.Entities;
using Orderly.API.Extensions;
using Orderly.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.    
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();

await seeder.Seed();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<LongRequestLoggingMiddleware>();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
