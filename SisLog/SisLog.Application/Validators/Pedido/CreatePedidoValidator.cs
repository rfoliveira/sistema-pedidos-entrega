using FluentValidation;
using SisLog.Application.Commands.Pedido;

namespace SisLog.Application.Validators.Pedido;

internal class CreatePedidoValidator : AbstractValidator<CreatePedidoCommand>
{
    public CreatePedidoValidator()
    {
        RuleFor(p => p.UsuarioId).Must(v => v > 0);
        RuleFor(p => p.Descricao).NotEmpty().MaximumLength(200);
        RuleFor(p => p.Rua).NotEmpty().MaximumLength(200);
        RuleFor(p => p.CEP).NotEmpty().MaximumLength(8);
        RuleFor(p => p.Bairro).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Cidade).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Estado).NotEmpty().MaximumLength(50);
    }
}
