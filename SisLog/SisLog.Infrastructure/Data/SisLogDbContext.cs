using Microsoft.EntityFrameworkCore;
using SisLog.Domain.Entities;
using SisLog.Infrastructure.Data.Configurations;

namespace SisLog.Infrastructure.Data;

public class SisLogDbContext : DbContext
{
    public SisLogDbContext(DbContextOptions<SisLogDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Entrega> Entregas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioEntityTypeConfiguration).Assembly);
    }
}
