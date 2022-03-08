using Financa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financa.Infra.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(ct => ct.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(200)");
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(250)");

            builder.HasMany(c => c.Lancamentos)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            builder.HasMany(c => c.Cartoes)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
