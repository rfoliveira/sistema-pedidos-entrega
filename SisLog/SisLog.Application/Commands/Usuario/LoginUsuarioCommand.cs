using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Commands.Usuario;

public record LoginUsuarioCommand(string Email, string Senha) : IRequest<LoginResponse>;