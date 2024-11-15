using Microsoft.EntityFrameworkCore;
using SisLog.Domain.Entities;
using SisLog.Infrastructure.Data.Configurations;

namespace SisLog.Infrastructure.Data;

public class SisLogContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Entrega> Entregas { get; set; }

    public SisLogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioEntityTypeConfiguration).Assembly);
    }
}
