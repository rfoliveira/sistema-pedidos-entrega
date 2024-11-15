using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Commands.Usuario;

public record CreateUsuarioCommand(
    string Nome,
    string Email,
    string Senha) : IRequest<UsuarioResponse>;