using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLog.Domain.Entities;

namespace SisLog.Infrastructure.Data.Configurations;

public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Senha)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.CriadoEm).IsRequired();
    }
}
