using MediatR;

namespace SisLog.Application.Commands.Pedido;

public record UpdateEntregaCommand(int Id, DateTime DataHoraEntrega) : IRequest<Unit>;