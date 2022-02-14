using Financa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Infra.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(ct => ct.Id);
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(150)");
            builder.Property(p => p.Cor).HasColumnType("VARCHAR(10)");

            builder.HasMany(c => c.Lancamentos)
                .WithOne(c => c.Categoria)
                .HasForeignKey(c => c.CategoriaId);
        }
    }
}
