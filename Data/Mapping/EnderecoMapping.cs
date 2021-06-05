using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).HasMaxLength(14).HasColumnType("varchar");
            builder.Property(x => x.Pais).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Estado).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Cidade).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Rua).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Numero).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(x => x.Complemento).HasMaxLength(2000).HasColumnType("varchar");

            builder.ToTable("Enderecos");
        }
    }
}
