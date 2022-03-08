using Financa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Infra.Configurations
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamentos");
            builder.HasKey(ct => ct.Id);
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(150)");
            builder.Property(p => p.Valor).HasPrecision(14, 2);
            builder.Property(p => p.TipoLancamento).HasConversion<int>();

            builder.HasOne(l => l.Categoria)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(p => p.CategoriaId)
                .IsRequired()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

            builder.HasOne(l => l.Usuario)
                .WithMany(u => u.Lancamentos)
                .HasForeignKey(l => l.UsuarioId);

            builder.HasOne(l => l.Cartao)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(p => p.CartaoId)
                .IsRequired()
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasMany(l => l.Itens)
                .WithOne(i => i.Lancamento)
                .HasForeignKey(l => l.LancamentoId);

        }
    }
}
