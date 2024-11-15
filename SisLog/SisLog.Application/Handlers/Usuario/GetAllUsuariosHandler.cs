using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioResponse>>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<GetAllUsuariosHandler> _logger;

    public GetAllUsuariosHandler(IUsuarioRepository repo, ILogger<GetAllUsuariosHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<IEnumerable<UsuarioResponse>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _repo.GetAllAsync();
        _logger.LogInformation("Retornados {Qtd} usuários", usuarios.Count);

        return usuarios.Adapt<IEnumerable<UsuarioResponse>>();
    }
}
