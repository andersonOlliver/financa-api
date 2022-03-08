using Financa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Infra.Configurations
{
    public class CartaoConfiguration : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartoes");
            builder.HasKey(ct => ct.Id);
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(150)");
            builder.Property(p => p.DiaVencimento).HasColumnType("TINYINT");
            builder.Property(p => p.DiaFechamento).HasColumnType("TINYINT");

            //builder.HasMany(c => c.Lancamentos)
            //    .WithOne(c => c.Categoria)
            //    .HasForeignKey(c => c.CategoriaId);
        }
    }
}
