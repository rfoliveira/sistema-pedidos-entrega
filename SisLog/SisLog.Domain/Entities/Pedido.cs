namespace SisLog.Domain.Entities;

public class Pedido: BaseEntity
{
    public int Numero { get; set; }
    public string Descricao { get; set; } = default!;
    public decimal Valor { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int EntregaId { get; set; }
    public Entrega Entrega { get; set; } = null!;
}
