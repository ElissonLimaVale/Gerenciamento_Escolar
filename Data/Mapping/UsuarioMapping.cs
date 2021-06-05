using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Senha).HasMaxLength(100).HasColumnType("varchar");

            builder.HasMany(x => x.Permissoes).WithMany(x => x.Usuarios).UsingEntity(join => join.ToTable("UsuariosPermissoes"));
            //builder.HasOne(x => x.Licenca).WithOne();

            builder.ToTable("Usuarios");
        }
    }
}
