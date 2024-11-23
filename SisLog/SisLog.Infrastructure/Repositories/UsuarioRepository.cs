using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;

namespace SisLog.Infrastructure.Repositories;

public class UsuarioRepository(SisLogDbContext dbContext) : BaseRepository<Usuario>(dbContext), IUsuarioRepository
{
    public async Task<Usuario?> GetByNome(string nome)
    {
        return (await GetAllAsync(u => u.Nome == nome)).FirstOrDefault();
    }

    public async Task<Usuario?> GetByEmail(string email)
    {
        return (await GetAllAsync(u => u.Email == email)).FirstOrDefault();
    }
}
