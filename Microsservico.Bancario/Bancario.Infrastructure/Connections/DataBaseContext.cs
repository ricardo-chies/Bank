using Bancario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bancario.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ContaBancaria> Conta_Bancaria { get; set; }
        public DbSet<MovimentacaoFinanceira> Movimentacao_Financeira { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        // Se necessário, você pode adicionar métodos de configuração adicional aqui

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você pode configurar o modelo de banco de dados, se necessário
            base.OnModelCreating(modelBuilder);
        }
    }
}