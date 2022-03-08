using Financa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Infra.Configurations
{
    public class ItemLancamentoConfiguration : IEntityTypeConfiguration<ItemLancamento>
    {
        public void Configure(EntityTypeBuilder<ItemLancamento> builder)
        {
            builder.ToTable("ItensLancamento");
            builder.HasKey(ct => ct.Id);
            builder.Property(p => p.Valor).HasPrecision(14, 2);


        }
    }
}
