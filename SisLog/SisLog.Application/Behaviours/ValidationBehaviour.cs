using FluentValidation;
using MediatR;

namespace SisLog.Application.Behaviours;

/// <summary>
/// Classe responsável por gerenciar as validações de modelo no mediatr
/// </summary>
/// <typeparam name="TRequest">Modelo definido de Request</typeparam>
/// <typeparam name="TResponse">Modelo definido de Response</typeparam>
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            // verifica as regras de validação uma por uma, retornando seu resultado
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            // Obtém a lista de falhas
            var failures = validationResults.SelectMany(ve => ve.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);
        }

        // Estando tudo OK, prossegue com o fluxo
        return await next();
    }
}
