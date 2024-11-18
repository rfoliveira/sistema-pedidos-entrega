using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class EntregaEntityTypeConfiguration : IEntityTypeConfiguration<Entrega>
{
    public void Configure(EntityTypeBuilder<Entrega> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Numero).IsRequired();
        builder.HasOne(e => e.Pedido)
            .WithOne(p => p.Entrega)
            .HasForeignKey<Entrega>(e => e.PedidoId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
