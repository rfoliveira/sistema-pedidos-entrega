using MediatR;
using Microsoft.Extensions.Logging;

namespace SisLog.Application.Behaviours;
/// <summary>
/// Classe responsável por gerenciar exceções nào trataas pelo pipeline de validação do mediatr.
/// </summary>
/// <typeparam name="TRequest">Modelo definido de Request</typeparam>
/// <typeparam name="TResponse">Modelo definido de Response</typeparam>
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "Unhandled exception occurred: {RequestName}, {Request}", requestName, request);
            throw;
        }
    }
}
