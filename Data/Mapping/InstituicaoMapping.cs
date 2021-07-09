using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class InstituicaoMapping : IEntityTypeConfiguration<Instituicao>
    {
        public void Configure(EntityTypeBuilder<Instituicao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.EmailCordenador).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.TelefoneCordenador).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.CelularCordenador).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.DataBase).HasMaxLength(1000).HasColumnType("varchar");

            //relacionamentos
            //builder.HasOne(x => x.Licenca).WithOne();
            //builder.HasMany(x => x.Usuarios).WithOne().HasForeignKey(x => x.InstituicaoId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Instituicoes");
        }
    }
}
