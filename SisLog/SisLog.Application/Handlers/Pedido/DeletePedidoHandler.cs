using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Pedido;
using SisLog.Application.Exceptions.Pedido;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Pedido;

public class DeletePedidoHandler : IRequestHandler<DeletePedidoCommand, Unit>
{
    private readonly IPedidoRepository _repo;
    private readonly ILogger<DeletePedidoHandler> _logger;

    public DeletePedidoHandler(IPedidoRepository repo, ILogger<DeletePedidoHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _repo.GetByIdAsync(request.Id);

        if (pedido == null)
        {
            _logger.LogInformation("Pedido #{Id} não encontrado", request.Id);
            throw new PedidoNaoEncontradoException("Id", request.Id);
        }

        await _repo.DeleteAsync(pedido);

        return Unit.Value;
    }
}
