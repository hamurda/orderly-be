﻿using Microsoft.OpenApi.Models;
using Orderly.API.Middlewares;
using Serilog;
using System.Runtime.CompilerServices;

namespace Orderly.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {

        builder.Services.AddAuthentication();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type =  ReferenceType.SecurityScheme, Id="bearerAuth"}
            },
            []
        }

    });

        });


        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<LongRequestLoggingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
    );

    }
}
