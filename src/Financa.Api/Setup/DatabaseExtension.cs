using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Api.Setup
{
    public static class DatabaseExtension
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CatalogoContext>(opt => opt.UseInMemoryDatabase("CatalogoDB"));
            services.AddDbContext<FinancaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
