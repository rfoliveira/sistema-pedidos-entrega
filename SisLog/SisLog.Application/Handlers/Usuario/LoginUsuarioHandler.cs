using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Responses.Usuario;
using SisLog.Domain.Extensions;
using SisLog.Domain.Repositories;

namespace SisLog.Application.Handlers.Usuario;

public class LoginUsuarioHandler : IRequestHandler<LoginUsuarioCommand, LoginResponse>
{
    private readonly IUsuarioRepository _repo;
    private readonly ILogger<LoginUsuarioHandler> _logger;

    public LoginUsuarioHandler(IUsuarioRepository repo, ILogger<LoginUsuarioHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<LoginResponse> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repo.GetByEmail(request.Email);

        if (usuario == null)
        {
            _logger.LogInformation("Usuário não encontrado");
            throw new UsuarioNaoEncontradoException("Email", request.Email);
        }

        var senhaOK = request.Senha.Verify(usuario.Senha);

        if (!senhaOK)
        {
            _logger.LogInformation("Usuário e/ou senha inválida");
            throw new UsuarioEmailSenhaInvalidoException();
        }

        return usuario.Adapt<LoginResponse>();
    }
}
