using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SisLog.Application;
using SisLog.Infrastructure;

namespace SisLog.API;

internal static class Setup
{
    static string CorsPolicyName => "CorsPolicy";

    public static IHostApplicationBuilder AddAPI(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, policy =>
            {
                policy.AllowAnyOrigin();
                policy.WithMethods("GET", "POST", "PUT", "DELETE");
            });
        });

        return builder;
    }

    public static void CheckDevModeConfig(this IHost host, IWebHostEnvironment env)
    {
        var app = (IApplicationBuilder)host;

        if (env.IsDevelopment())
        {
            host.ExecuteMigrations();

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(CorsPolicyName);
    }

    public static void AddHealthCheckEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
