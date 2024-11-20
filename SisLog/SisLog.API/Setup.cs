using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SisLog.Application;
using SisLog.Domain.Settings;
using SisLog.Infrastructure;
using System.Text;

namespace SisLog.API;

internal static class Setup
{
    static string CorsPolicyName => "CorsPolicy";

    public static IHostApplicationBuilder AddAPI(this IHostApplicationBuilder builder)
    {
        builder.AddJwt();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGenWithAuth();

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

    private static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter your JWT token in this field",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT"
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    []
                }
            };

            options.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    private static void AddJwt(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
        builder.Services.AddSingleton<ITokenSettings>(sp => sp.GetRequiredService<IOptions<TokenSettings>>().Value);

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSettings:SecretKey"]!)),
                    ValidIssuer = builder.Configuration["TokenSettings:Issuer"],
                    ValidAudience = builder.Configuration["TokenSettings:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
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
