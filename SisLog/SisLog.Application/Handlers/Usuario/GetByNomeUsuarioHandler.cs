using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class GetByNomeUsuarioHandler : IRequestHandler<GetByNomeUsuarioQuery, UsuarioResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<GetByNomeUsuarioHandler> _logger;

    public GetByNomeUsuarioHandler(IUsuarioRepository repo, ILogger<GetByNomeUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<UsuarioResponse> Handle(GetByNomeUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repo.GetByNome(request.Nome);

        if (usuario == null)
        {
            _logger.LogInformation("Usuário com Nome {Nome} não encontrado", request.Nome);
            throw new UsuarioNotFoundException("Nome", request.Nome);
        }

        return usuario.Adapt<UsuarioResponse>();
    }
}
