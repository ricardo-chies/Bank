using AutoMapper;
using Bancario.Application.Interfaces;
using Bancario.Application.Mappings;
using Bancario.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bancario.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Configure AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UsuarioProfile());
                mc.AddProfile(new ContaBancariaProfile());
                mc.AddProfile(new MovimentacaoFinanceiraProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IContaBancariaService, ContaBancariaService>();
            services.AddTransient<IMovimentacaoFinanceiraService, MovimentacaoFinanceiraService>();

            return services;
        }
    }
}
