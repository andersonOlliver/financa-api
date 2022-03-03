using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;
using Financa.Domain.Services;
using Financa.Infra.Context;
using Financa.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financa.IoC
{
    public class DependencyInjection
    {
        public static IServiceCollection InitializeDependencies(IServiceCollection services)
        {
            services.AddScoped<FinancaContext>();

            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            //services.AddScoped<ILancamentoAppService, LancamentoAppService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            //services.AddScoped<ICategoriaAppService, CategoriaAppService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IAuthAppService, AuthAppService>();
            //services.AddScoped<IJwtUtil, JwtUtil>();


            return services;
        }
    }
}
