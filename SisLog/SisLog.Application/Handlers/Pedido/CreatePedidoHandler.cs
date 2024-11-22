using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Pedido;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Responses.Pedido;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Pedido;

public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, PedidoResponse>
{
    private readonly IPedidoRepository _pedidoRepo;
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly ILogger<CreatePedidoHandler> _logger;

    public CreatePedidoHandler(IPedidoRepository pedidoRepo, IUsuarioRepository usuarioRepo, ILogger<CreatePedidoHandler> logger)
    {
        _pedidoRepo = pedidoRepo;
        _usuarioRepo = usuarioRepo;
        _logger = logger;
    }

    public async Task<PedidoResponse> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepo.GetByIdAsync(request.UsuarioId);

        if (usuario == null)
        {
            _logger.LogInformation("Usuário #{Id} não encontrado para este pedido", request.UsuarioId);
            throw new UsuarioNaoEncontradoException("Id", request.UsuarioId);
        }

        var pedido = request.Adapt<Domain.Entities.Pedido>();
        pedido.Numero = await _pedidoRepo.GerarNumeroPedidoByUsuarioAsync(request.UsuarioId);

        var pedidoNovo = await _pedidoRepo.CreateAsync(pedido);
        _logger.LogInformation("Pedido #{Numero} criado com sucesso", pedidoNovo.Numero);

        return pedidoNovo.Adapt<PedidoResponse>();
    }
}
