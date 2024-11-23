using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Extensions;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, UsuarioResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<CreateUsuarioHandler> _logger;

    public CreateUsuarioHandler(IUsuarioRepository repo, ILogger<CreateUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<UsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioNovo = request.Adapt<Domain.Entities.Usuario>();
        usuarioNovo.Senha = request.Senha.Hash();
        usuarioNovo = await _repo.CreateAsync(usuarioNovo);

        if (usuarioNovo.Id > 0)
            _logger.LogInformation("Usuário {Nome} inserido com sucesso", request.Nome);

        return usuarioNovo.Adapt<UsuarioResponse>();
    }
}