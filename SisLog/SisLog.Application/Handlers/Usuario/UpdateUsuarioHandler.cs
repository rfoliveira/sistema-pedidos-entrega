using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Extensions;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<UpdateUsuarioHandler> _logger;

    public UpdateUsuarioHandler(IUsuarioRepository repo, ILogger<UpdateUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioAAlterar = await _repo.GetByIdAsync(request.Id);

        if (usuarioAAlterar == null)
        {
            _logger.LogInformation("Usuário com ID {Id} não encontrado", request.Id);
            throw new UsuarioNaoEncontradoException("ID", request.Id);
        }

        usuarioAAlterar.Nome = request.Nome;
        usuarioAAlterar.Email = request.Email;
        usuarioAAlterar.Senha = request.Senha.Hash();

        var usuario = usuarioAAlterar.Adapt<Domain.Entities.Usuario>();
        usuario = await _repo.UpdateAsync(usuario);

        if (usuario != null)
            _logger.LogInformation("Usuario alterado com sucesso");

        return Unit.Value;
    }
}
