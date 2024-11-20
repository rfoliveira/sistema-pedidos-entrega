using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<DeleteUsuarioHandler> _logger;

    public DeleteUsuarioHandler(IUsuarioRepository repo, ILogger<DeleteUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioARemover = await _repo.GetByIdAsync(request.Id);

        if (usuarioARemover == null)
        {
            _logger.LogInformation("Usuário com ID {Id} não encontrado", request.Id);
            throw new UsuarioNaoEncontradoException("ID", request.Id);
        }

        var usuario = usuarioARemover.Adapt<Domain.Entities.Usuario>();
        var retorno = await _repo.DeleteAsync(usuario);

        if (retorno)
            _logger.LogInformation("Usuario removido com sucesso");

        return Unit.Value;
    }
}
