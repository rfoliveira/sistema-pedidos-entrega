namespace SisLog.Domain.Entities;

public class Pedido: BaseEntity
{
    public int Numero { get; set; }
    public string Descricao { get; set; } = default!;
    public decimal Valor { get; set; }
    public string Rua { get; set; } = default!;
    public string CEP { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Estado { get; set; } = default!;
    public DateTime? DataHoraEntrega { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
}
