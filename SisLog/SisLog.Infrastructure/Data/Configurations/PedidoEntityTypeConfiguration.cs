using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.Property(p => p.Numero).IsRequired();
        
        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Valor)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.UsuarioId).IsRequired();
        builder.HasOne(p => p.Usuario);

        builder.Property(p => p.Entrega).IsRequired();
        builder.HasOne(p => p.Entrega);        
    }
}
