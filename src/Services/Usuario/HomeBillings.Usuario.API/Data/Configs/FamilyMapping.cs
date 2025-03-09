using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBillings.Usuario.API.Data.Configs
{
    public class FamilyMapping : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.ToTable("FAMILIAS", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.Name)
                .HasColumnName("NOME")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("TIPO_PESSOA")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.CreatedIn)
                .HasColumnName("CRIADO_EM")
                .IsRequired();

            builder.HasMany(p => p.Users)
                .WithOne(p => p.Family)
                .HasForeignKey(p => p.FamilyId)
                .HasPrincipalKey(p => p.Id);

            builder.Ignore(p => p.Notifications);
        }
    }
}
