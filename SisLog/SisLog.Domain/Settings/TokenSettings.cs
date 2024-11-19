namespace SisLog.Domain.Settings;

public class TokenSettings : ITokenSettings
{
    public string Audience { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public int ExpirationTimeInMinutes { get; set; }
    public string SecretKey { get; set; } = default!;
}
