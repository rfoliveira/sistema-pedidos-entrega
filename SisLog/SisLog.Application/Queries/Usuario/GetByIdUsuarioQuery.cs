using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Queries.Usuario;

public record GetByIdUsuarioQuery(int Id) : IRequest<UsuarioResponse>;