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

            
        }
    }
}
