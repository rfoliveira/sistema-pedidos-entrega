using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;
using SisLog.Infrastructure.Repositories;

namespace SisLog.Infrastructure;

public static class Setup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<SisLogDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServerConnection")));
        services.AddHealthChecks().AddDbContextCheck<SisLogDbContext>("SisLog Sql Server Health Check", tags: ["sqlserver"]);

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        
        return services;
    }

    public static void ExecuteMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<SisLogDbContext>>();
        var context = services.GetRequiredService<SisLogDbContext>();

        try
        {
            logger.LogInformation("Executando migrations");
            var retry = Policy.Handle<SqlException>()
                .WaitAndRetry(
                    retryCount: 5,
                    sleepDurationProvider: retryAttemp => TimeSpan.FromSeconds(30),
                    onRetry: (exception, span, count) =>
                    {
                        logger.LogError("Tentando novamente devido ao erro {Erro} em {Intervalo}", exception.Message, span);
                    }
                );

            retry.Execute(() =>
            {
                context.Database.Migrate();
            });

            logger.LogInformation("Migrations executado com sucesso");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao executar as migrations");
        }
    }
}
