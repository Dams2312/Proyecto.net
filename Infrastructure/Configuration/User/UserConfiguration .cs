using Domain.ValueObject.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.User;

public sealed class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.Users.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Users.User> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Ignore(x => x.Code);

        builder.Property(x => x.RoleId)
            .HasConversion(x => x.Value, x => UsersrolId.Create(x))
            .HasColumnName("rol_id")
            .IsRequired();

        builder.Property(x => x.Mail)
            .HasConversion(x => x.Value, x => UsersMail.Create(x))
            .HasColumnName("correo")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => UsersPassword.Create(x))
            .HasColumnName("password_hash")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Names)
            .HasConversion(x => x.Value, x => UsersNames.Create(x))
            .HasColumnName("nombres")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Surnames)
            .HasConversion(x => x.Value, x => UsersSurnames.Create(x))
            .HasColumnName("apellidos")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(x => x.Value, x => UsersActive.Create(x))
            .HasColumnName("activo")
            .IsRequired();

        builder.Property(x => x.CreateDate)
            .HasConversion(x => x.Value, x => UsersCreateDate.Create(x))
            .HasColumnName("fecha_creacion")
            .IsRequired();

        builder.Property(x => x.FinishDate)
            .HasConversion(x => x.Value, x => UsersFinishDate.Create(x))
            .HasColumnName("fecha_fin");

        builder.HasIndex(x => x.Mail).IsUnique();

    }
}
