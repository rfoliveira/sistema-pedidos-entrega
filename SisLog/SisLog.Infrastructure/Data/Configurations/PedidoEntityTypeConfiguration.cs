using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Numero).IsRequired();
        builder.Property(p => p.Descricao).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Valor).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Rua).IsRequired().HasMaxLength(200);
        builder.Property(e => e.CEP).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);

        builder.HasOne(p => p.Usuario)
            .WithMany(u => u.Pedidos)
            .HasForeignKey(p => p.UsuarioId)
            .HasConstraintName("FK_Usuario")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
