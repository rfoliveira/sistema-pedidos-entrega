using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class GetByEmailUsuarioHandler : IRequestHandler<GetByEmailUsuarioQuery, UsuarioResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<GetByEmailUsuarioHandler> _logger;

    public GetByEmailUsuarioHandler(IUsuarioRepository repo, ILogger<GetByEmailUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<UsuarioResponse> Handle(GetByEmailUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repo.GetByEmail(request.Email);

        if (usuario == null)
        {
            _logger.LogInformation("Usuário com Email {Email} não encontrado", request.Email);
            throw new UsuarioNotFoundException("Email", request.Email);
        }

        return usuario.Adapt<UsuarioResponse>();
    }
}
