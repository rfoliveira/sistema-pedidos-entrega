using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, UsuarioResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<UpdateUsuarioHandler> _logger;

    public UpdateUsuarioHandler(IUsuarioRepository repo, ILogger<UpdateUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<UsuarioResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioAAlterar = await _repo.GetByIdAsync(request.Id);

        if (usuarioAAlterar == null)
        {
            _logger.LogInformation("Usuário com ID {Id} não encontrado", request.Id);
            throw new UsuarioNotFoundException("ID", request.Id);
        }

        var usuario = usuarioAAlterar.Adapt<Domain.Entities.Usuario>();
        usuario = await _repo.UpdateAsync(usuario);

        if (usuario != null)
            _logger.LogInformation("Usuario alterado com sucesso");

        return usuario.Adapt<UsuarioResponse>();
    }
}
