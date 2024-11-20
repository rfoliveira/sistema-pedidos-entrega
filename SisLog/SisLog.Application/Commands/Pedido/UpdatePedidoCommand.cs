using MediatR;

namespace SisLog.Application.Commands.Pedido;

public record UpdatePedidoCommand(int Id, string Descricao, decimal Valor) : IRequest<Unit>;