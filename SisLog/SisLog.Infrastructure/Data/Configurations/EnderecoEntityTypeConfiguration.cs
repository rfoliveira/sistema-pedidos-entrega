using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.Property(e => e.Rua).IsRequired().HasMaxLength(200);
        builder.Property(e => e.CEP).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);

        builder.HasOne(e => e.Entrega)
            .WithOne(e => e.Endereco)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
