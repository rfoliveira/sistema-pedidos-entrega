using System.Security.Cryptography;

namespace SisLog.Domain.Extensions;

public static class PasswordExtensions
{
    const int SaltSize = 16;
    const int HashSize = 32;
    const int Interactions = 100000;
    static HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public static string Hash(this string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Interactions, Algorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public static bool Verify(this string password, string passwordHash)
    {
        var parts = passwordHash.Split("-");
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Interactions, Algorithm, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}
