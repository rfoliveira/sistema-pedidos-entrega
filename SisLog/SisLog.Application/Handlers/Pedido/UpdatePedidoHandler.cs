using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Pedido;
using SisLog.Application.Exceptions.Pedido;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Pedido;

public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, Unit>
{
    private readonly IPedidoRepository _repo;
    private readonly ILogger<UpdatePedidoHandler> _logger;

    public UpdatePedidoHandler(IPedidoRepository repo, ILogger<UpdatePedidoHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = await _repo.GetByIdAsync(request.Id);

        if (pedido == null)
        {
            _logger.LogInformation("Pedido #{Id} não encontrado", request.Id);
            throw new PedidoNaoEncontradoException("Id", request.Id);
        }

        pedido.Descricao = request.Descricao;
        pedido.Valor = request.Valor;

        var pedidoAAlterar = pedido.Adapt<Domain.Entities.Pedido>();
        await _repo.UpdateAsync(pedidoAAlterar);

        return Unit.Value;
    }
}
