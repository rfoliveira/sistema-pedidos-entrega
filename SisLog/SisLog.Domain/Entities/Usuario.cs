namespace SisLog.Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public ICollection<Pedido> Pedidos { get; set; } = [];
}

