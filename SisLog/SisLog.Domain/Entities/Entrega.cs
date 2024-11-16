namespace SisLog.Domain.Entities;

public class Entrega : BaseEntity
{
    public int Numero { get; set; }
    public DateTime? DataHoraEntrega { get; set; }
    public Endereco Endereco { get; set; } = null!;
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
}
