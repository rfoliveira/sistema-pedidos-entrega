using SisLog.Domain.Entities;

namespace SisLog.Domain.Repositories;

public interface IPedidoRepository : IBaseRepository<Pedido>
{
    Task<int> GetPedidosUsuarioCountAsync(int usuarioId);
    Task<IEnumerable<Pedido>> GetByUsuarioAsync(int usuarioId);
}
