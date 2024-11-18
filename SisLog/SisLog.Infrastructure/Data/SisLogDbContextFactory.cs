using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SisLog.Infrastructure.Data;

/// <summary>
/// Classe necessária para a execução do migrations
/// </summary>
/// <param name="config"></param>
public class SisLogDbContextFactory(IConfiguration config) : IDesignTimeDbContextFactory<SisLogDbContext>
{
    private readonly IConfiguration _config = config;

    public SisLogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SisLogDbContext>();
        optionsBuilder.UseSqlServer(_config.GetConnectionString("SqlServerConnection"));

        return new SisLogDbContext(optionsBuilder.Options);
    }
}
