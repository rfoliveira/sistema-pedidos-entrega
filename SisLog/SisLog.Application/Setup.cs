using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SisLog.Application.Behaviours;
using SisLog.Application.Handlers.Usuario;
using System.Reflection;

namespace SisLog.Application;

public static class Setup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            // registro de todos os handlers usando reflection
            cfg.RegisterServicesFromAssemblies(typeof(GetByIdUsuarioHandler).Assembly);

            // registro dos pipelines de validação dos objetos de request e response
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        // registro dos validadores
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
