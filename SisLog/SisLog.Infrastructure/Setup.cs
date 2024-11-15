using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;
using SisLog.Infrastructure.Repositories;

namespace SisLog.Infrastructure;

public static class Setup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<SisLogContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServerConnection")));
        services.AddHealthChecks().AddDbContextCheck<SisLogContext>("SisLog Sql Server Health Check", tags: ["sqlserver"]);

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IEntregaRepository, EntregaRepository>();
        
        return services;
    }
}
