using Financa.Domain.Entities;
using Financa.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Financa.Infra.Context
{
    public class FinancaContext : DbContext, IUnitOfWork
    {
        public FinancaContext(DbContextOptions<FinancaContext> options) : base(options)
        { }

        public FinancaContext()
        { }


        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<ItemLancamento> ItensLancamento { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }

        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;
            //if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancaContext).Assembly);
            MapearPropriedadesEsquecidas(modelBuilder);
        }

        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            //AdicionaProvisorio(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string) || p.ClrType == typeof(decimal));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        property.SetMaxLength(100);
                        property.SetPrecision(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
