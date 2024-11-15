using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Queries.Usuario;

public record GetAllUsuariosQuery() : IRequest<IEnumerable<UsuarioResponse>>;