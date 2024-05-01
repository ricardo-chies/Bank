using Bancario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ContaBancaria> ContasBancarias { get; set; }
    public DbSet<MovimentacaoFinanceira> MovimentacoesFinanceiras { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_configuration["ConnectionStrings:Local"]!, ServerVersion.AutoDetect(_configuration["ConnectionStrings:Local"]!));
        }
    }
}
