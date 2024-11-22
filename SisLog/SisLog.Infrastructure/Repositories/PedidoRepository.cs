using Microsoft.EntityFrameworkCore;
using SisLog.Domain.Entities;
using SisLog.Domain.Repositories;
using SisLog.Infrastructure.Data;

namespace SisLog.Infrastructure.Repositories;

public class PedidoRepository(SisLogDbContext dbContext) : BaseRepository<Pedido>(dbContext), IPedidoRepository
{
    public async Task<IEnumerable<Pedido>> GetByUsuarioAsync(int usuarioId)
    {
        return await DbContext.Pedidos.Where(p => p.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<int> GerarNumeroPedidoByUsuarioAsync(int usuarioId)
    {
        return (await DbContext.Pedidos.CountAsync(p => p.UsuarioId == usuarioId)) + 1;
    }
}
