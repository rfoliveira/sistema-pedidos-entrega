using MediatR;

namespace SisLog.Application.Commands.Pedido;

public record DeletePedidoCommand(int Id): IRequest<Unit>;