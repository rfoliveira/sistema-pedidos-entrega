using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class EntregaEntityTypeConfiguration : IEntityTypeConfiguration<Entrega>
{
    public void Configure(EntityTypeBuilder<Entrega> builder)
    {
        builder.Property(e => e.Numero).IsRequired();
        builder.Property(e => e.Endereco).IsRequired();
        builder.Property(e => e.PedidoId).IsRequired();
        builder.HasOne(e => e.Pedido);
    }
}
