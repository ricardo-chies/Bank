using Bancario.Domain.Interfaces;
using Bancario.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bancario.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DataBaseContext>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IContaBancariaRepository, ContaBancariaRepository>();
            services.AddTransient<IMovimentacaoFinanceiraRepository, MovimentacaoFinanceiraRepository>();

            return services;
        }
    }
}