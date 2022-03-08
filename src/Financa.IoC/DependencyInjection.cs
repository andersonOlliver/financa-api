using Financa.Domain.Interfaces.Repositories;
using Financa.Domain.Interfaces.Services;
using Financa.Domain.Services;
using Financa.Infra.Context;
using Financa.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financa.IoC
{
    public class Bootstrapper
    {
        public static IServiceCollection InitializeCrossDependencies(IServiceCollection services)
        {
            services.AddScoped<FinancaContext>();

            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<ICartaoRepository, CartaoRepository>();
            services.AddScoped<ICartaoService, CartaoService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();


            return services;
        }
    }
}
