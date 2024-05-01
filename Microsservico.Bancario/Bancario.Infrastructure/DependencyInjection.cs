using Bancario.Domain.Interfaces;
using Bancario.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bancario.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o contexto do banco de dados como Scoped
            services.AddDbContext<DataBaseContext>(options =>
                options.UseMySql(configuration.GetConnectionString("Local"), ServerVersion.AutoDetect(configuration.GetConnectionString("Local"))),
                ServiceLifetime.Scoped);

            // Registra os repositórios como Scoped
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
            services.AddScoped<IMovimentacaoFinanceiraRepository, MovimentacaoFinanceiraRepository>();

            return services;
        }
    }
}