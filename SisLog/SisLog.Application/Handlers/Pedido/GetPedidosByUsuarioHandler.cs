using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Queries.Pedido;
using SisLog.Application.Responses.Pedido;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Pedido;

public class GetPedidosByUsuarioHandler : IRequestHandler<GetPedidosByUsuarioQuery, IEnumerable<PedidoResponse>>
{
    private readonly IPedidoRepository _repo;
    private readonly ILogger<GetPedidosByUsuarioHandler> _logger;

    public GetPedidosByUsuarioHandler(IPedidoRepository repo, ILogger<GetPedidosByUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<IEnumerable<PedidoResponse>> Handle(GetPedidosByUsuarioQuery request, CancellationToken cancellationToken)
    {
        var pedidosUsuario = await _repo.GetByUsuarioAsync(request.UsuarioId);

        return pedidosUsuario.Adapt<IEnumerable<PedidoResponse>>();
    }
}
