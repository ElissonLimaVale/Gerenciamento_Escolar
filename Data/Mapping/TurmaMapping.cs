using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Serie).HasMaxLength(100).HasColumnType("varchar");

            builder.HasMany(x => x.Alunos).WithOne().HasForeignKey(x => x.TurmaId);

            builder.ToTable("Turmas");
        }
    }
}
