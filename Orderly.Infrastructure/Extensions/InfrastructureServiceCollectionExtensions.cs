using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orderly.Domain.Entities;
using Orderly.Domain.Repositories;
using Orderly.Infrastructure.Authorization;
using Orderly.Infrastructure.Persistence;
using Orderly.Infrastructure.Repositories;
using Orderly.Infrastructure.Seeders;

namespace Orderly.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OrderlyConnectionString");
        services.AddDbContext<OrderlyDbContext>(options =>
            options.UseNpgsql(connectionString)
            .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<OrderUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<OrderlyDbContext>();

        services.AddScoped<IRoleSeeder, RoleSeeder>();

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
