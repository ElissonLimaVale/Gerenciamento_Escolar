using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Telefone).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.Desciplina).HasMaxLength(100).HasColumnType("varchar");

            builder.HasOne(a => a.Endereco).WithOne();

            builder.ToTable("Professores");

        }
    }
}
