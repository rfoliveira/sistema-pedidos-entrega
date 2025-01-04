using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;

namespace SisLog.Application.Handlers.Usuario;

public class GetCurrentUserInfoHandler : IRequestHandler<GetCurrentUserInfoQuery, UsuarioResponse>
{
	private readonly IHttpContextAccessor _host;
	private readonly ILogger<GetCurrentUserInfoHandler> _logger;

	public GetCurrentUserInfoHandler(IHttpContextAccessor host, ILogger<GetCurrentUserInfoHandler> logger)
	{
		_host = host;
		_logger = logger;
	}

	public Task<UsuarioResponse> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
	{
		foreach (var claim in _host.HttpContext.User.Claims)
		{
			_logger.LogInformation("Claim Type = {ClaimType}, Claim Value = {ClaimValue}, Claim.ValueType = {ClaimValueType}", claim.Type, claim.Value, claim.ValueType);
		}

		return Task.FromResult(new UsuarioResponse(99, "teste", "teste@teste.com", DateTime.Now, null, null));
	}
}
