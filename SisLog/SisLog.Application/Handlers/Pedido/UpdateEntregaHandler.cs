using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Pedido;
using SisLog.Application.Exceptions.Pedido;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Pedido;

public class UpdateEntregaHandler : IRequestHandler<UpdateEntregaCommand, Unit>
{
    private readonly IPedidoRepository _repo;
    private readonly ILogger<UpdateEntregaHandler> _logger;

    public UpdateEntregaHandler(IPedidoRepository repo, ILogger<UpdateEntregaHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateEntregaCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _repo.GetByIdAsync(request.Id);

        if (pedido == null)
        {
            _logger.LogInformation("Pedido #{Id} não encontrado", request.Id);
            throw new PedidoNaoEncontradoException("Id", request.Id);
        }

        pedido.DataHoraEntrega = request.DataHoraEntrega;
        await _repo.UpdateAsync(pedido);

        return Unit.Value;
    }
}
