using Financa.Domain.Entities;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Financa.Api.Setup
{
    public static class DatabaseExtension
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //return InitializeDockerDatabase(services, configuration);
            return InitializeLocalDatabase(services, configuration);
        }

        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<FinancaContext>();
            if (context is not null && context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            if (context is not null && !context.Categorias.Any())
            {
                context.Categorias.AddRange(Categoria.CategoriaFactory.CategoriasIniciais());
                context.Usuarios.Add(Usuario.UsuarioFactory.UsuarioInicial());
                context.SaveChanges();
            }
        }

        public static IServiceCollection InitializeDockerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "SQLServerConnection";
            return services.AddDbContext<FinancaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString(connectionString)));
        }

        public static IServiceCollection InitializeLocalDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "DefaultConnection";
            return services.AddDbContext<FinancaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString(connectionString)));
        }

        //public static IServiceCollection InitializeInMemoryDatabase(this IServiceCollection services, IConfiguration configuration)
        //{
        //    return services.AddDbContext<FinancaContext>(opt => opt.UseInMemoryDatabase("FinancaDb"));
        //}
    }
}
