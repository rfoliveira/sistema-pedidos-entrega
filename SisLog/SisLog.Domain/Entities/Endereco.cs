namespace SisLog.Domain.Entities;

public class Endereco : BaseEntity
{
    public string Rua { get; set; } = default!;
    public string CEP { get; set; } = default!;
    public int? Numero { get; set; }
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Estado { get; set; } = default!;

    public Entrega? Entrega { get; set; }
}
