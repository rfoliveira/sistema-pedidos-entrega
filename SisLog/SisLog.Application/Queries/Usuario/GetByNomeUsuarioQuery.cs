using MediatR;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Queries.Usuario;

public record GetByNomeUsuarioQuery(string Nome) : IRequest<UsuarioResponse>;