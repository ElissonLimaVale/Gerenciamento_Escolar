

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class PermissaoMapping : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Permission).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(x => x.Nivel).HasMaxLength(50).HasColumnType("varchar");

            builder.ToTable("Permissoes");
        }
    }
}
