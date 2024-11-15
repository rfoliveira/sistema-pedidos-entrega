
namespace SisLog.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public DateTime? RemovidoEm { get; set; }
}
