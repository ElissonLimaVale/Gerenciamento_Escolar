using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGIEscolar.Data.Models;

namespace SGIEscolar.Data.Mapping
{
    public class LicencaMapping : IEntityTypeConfiguration<Licenca>
    {
        public void Configure(EntityTypeBuilder<Licenca> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).HasMaxLength(200).HasColumnType("varchar");
            builder.Property(x => x.DataInicio).HasColumnType("datetime");
            builder.Property(x => x.DataFim).HasColumnType("datetime");

            builder.ToTable("Licencas");
        }
    }
}
