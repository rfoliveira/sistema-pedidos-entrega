using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;

namespace SisLog.Infrastructure.Repositories;

public class EntregaRepository(SisLogContext dbContext) : BaseRepository<Entrega>(dbContext), IEntregaRepository
{
}
