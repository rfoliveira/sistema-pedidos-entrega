using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class GetByIdUsuarioHandler : IRequestHandler<GetByIdUsuarioQuery, UsuarioResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<GetByIdUsuarioHandler> _logger;

    public GetByIdUsuarioHandler(IUsuarioRepository repo, ILogger<GetByIdUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<UsuarioResponse> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repo.GetByIdAsync(request.Id);

        if (usuario == null)
            _logger.LogInformation("Usuário com ID {Id} não encontrado", request.Id);

        return usuario.Adapt<UsuarioResponse>();
    }
}
