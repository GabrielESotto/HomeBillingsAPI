using HomeBillings.Usuario.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBillings.Entradas.API.Data.Configs
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USUARIOS", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.Name)
                .HasColumnName("NOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("SOBRENOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .HasColumnName("DATA_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.Age)
                .HasColumnName("IDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("TELEFONE")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Person)
                .HasColumnName("TIPO_PESSOA")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.PersonRegister)
                .HasColumnName("REGISTRO_PESSOA")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.HasOne(p => p.Address);

            builder.HasOne(p => p.Family)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.FamilyId)
                .HasPrincipalKey(p => p.Id);

            builder.Ignore(p => p.Notifications);
        }
    }
}
