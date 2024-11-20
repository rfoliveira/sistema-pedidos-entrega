using MediatR;

namespace SisLog.Application.Commands.Usuario;

public record UpdateUsuarioCommand(
    int Id, 
    string Nome,
    string Email,
    string Senha
) : IRequest<Unit>;