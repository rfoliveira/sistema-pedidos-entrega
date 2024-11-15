using SisLog.Domain.Entities;

namespace SisLog.Domain.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario?> GetByNome(string nome);
    Task<Usuario?> GetByEmail(string email);
}
