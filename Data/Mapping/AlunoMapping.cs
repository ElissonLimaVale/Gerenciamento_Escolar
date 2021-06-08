using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.CPF).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(x => x.DataNascimento).HasColumnType("datetime");
            builder.Property(x => x.NomeDaMae).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.NomeDoPai).HasMaxLength(100).HasColumnType("varchar");

            //relacionamentos 
            builder.HasOne(x => x.Endereco).WithOne();

            builder.ToTable("Alunos");
        }
    }
}
