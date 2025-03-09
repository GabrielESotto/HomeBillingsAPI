using HomeBillings.Entradas.API.Domain.Entities.Categoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBillings.Entradas.API.Data.Configs
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIAS", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.Name)
                .HasColumnName("NOME")
                .HasColumnType("varchar(36)")
                .IsRequired();

            builder.Property(p => p.CreatedIn)
                .HasColumnName("CRIADO_EM")
                .IsRequired();

            builder.Property(p => p.Acronym)
                .HasColumnName("SIGLA")
                .HasColumnType("varchar(6)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(100)");
        }
    }
}
