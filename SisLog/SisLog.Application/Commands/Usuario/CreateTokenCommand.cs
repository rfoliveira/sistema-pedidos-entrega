using MediatR;

namespace SisLog.Application.Commands.Usuario;

public record CreateTokenCommand(int Id, string Nome, string Email) : IRequest<string>;