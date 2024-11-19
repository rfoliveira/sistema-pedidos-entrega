namespace SisLog.Domain.Settings;

public interface ITokenSettings
{
    string Audience { get; set; }
    string Issuer { get; set; }
    int ExpirationTimeInMinutes { get; set; }
    string SecretKey {  get; set; }
}
