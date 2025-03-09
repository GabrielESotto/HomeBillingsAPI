using HomeBillings.Entradas.API.Domain.Entities.Entrada;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBillings.Entradas.API.Data.Configs
{
    public class EntryMapping : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("ENTRADAS", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.CategoryId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnName("VALOR")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.EntryDate)
                .HasColumnName("DATA_ENTRADA")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Entries)
                .HasForeignKey(p => p.CategoryId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
