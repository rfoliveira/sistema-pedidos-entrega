using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Queries.Usuario;

public record GetCurrentUserInfoQuery : IRequest<UsuarioResponse>;