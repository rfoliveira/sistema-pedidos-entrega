using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;

namespace SisLog.Infrastructure.Repositories;

public class UsuarioRepository(SisLogContext dbContext) : BaseRepository<Usuario>(dbContext), IUsuarioRepository
{
    public async Task<Usuario?> GetByNome(string nome)
    {
        return (await GetAllAsync(u => u.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase))).FirstOrDefault();
    }

    public async Task<Usuario?> GetByEmail(string email)
    {
        return (await GetAllAsync(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))).FirstOrDefault();
    }
}
