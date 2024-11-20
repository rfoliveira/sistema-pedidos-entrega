using MediatR;

namespace SisLog.Application.Commands.Usuario;

public record DeleteUsuarioCommand(int Id) : IRequest<Unit>;