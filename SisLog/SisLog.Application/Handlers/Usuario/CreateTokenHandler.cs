using MediatR;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SisLog.Application.Commands.Usuario;
using SisLog.Domain.Settings;
using System.Security.Claims;
using System.Text;

namespace SisLog.Application.Handlers.Usuario;

public class CreateTokenHandler(ITokenSettings tokenSettings) : IRequestHandler<CreateTokenCommand, string>
{
    private readonly ITokenSettings _tokenSettings = tokenSettings;

    public Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, request.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, request.Email),
                new Claim(JwtRegisteredClaimNames.Name, request.Nome)
            ]),
            Expires = DateTime.Now.AddMinutes(_tokenSettings.ExpirationTimeInMinutes),
            SigningCredentials = credentials,
            Issuer = _tokenSettings.Issuer,
            Audience = _tokenSettings.Audience
        };

        var handler = new JsonWebTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);

        return Task.FromResult(token);
    }
}
