using MediatR;
using SisLog.Application.Responses.Pedido;

namespace SisLog.Application.Queries.Pedido;

public record GetPedidosByUsuarioQuery(int UsuarioId) : IRequest<IEnumerable<PedidoResponse>>;