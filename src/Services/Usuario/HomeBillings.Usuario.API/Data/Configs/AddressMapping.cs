using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBillings.Usuario.API.Data.Configs
{
    public class CategoryMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ENDERECOS", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.StreetName)
                .HasColumnName("RUA")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Number)
                .HasColumnName("NUMERO")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Neighborhood)
                .HasColumnName("BAIRRO")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.City)
                .HasColumnName("CIDADE")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.ZipCode)
                .HasColumnName("CEP")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.State)
                .HasColumnName("ESTADO")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Ignore(p => p.Notifications);
        }
    }
}
