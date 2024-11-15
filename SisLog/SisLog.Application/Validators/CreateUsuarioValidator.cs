using FluentValidation;
using SisLog.Application.Commands.Usuario;

namespace SisLog.Application.Validators;

public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioValidator()
    {
        RuleFor(u => u.Nome)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(u => u.Email) 
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(u => u.Senha) 
            .NotEmpty()
            .MaximumLength(20);
    }
}
