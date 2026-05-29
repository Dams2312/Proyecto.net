using Domain.Entities.Users;
using Domain.ValueObject.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Users;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .HasConversion(
                x => x.Value,
                x => UsersCode.Create(x))
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Names)
            .HasConversion(
                x => x.Value,
                x => UsersNames.Create(x))
            .HasColumnName("names")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Surnames)
            .HasConversion(
                x => x.Value,
                x => UsersSurnames.Create(x))
            .HasColumnName("surnames")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Mail)
            .HasConversion(
                x => x.Value,
                x => UsersMail.Create(x))
            .HasColumnName("mail")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasConversion(
                x => x.Value,
                x => UsersPassword.Create(x))
            .HasColumnName("password")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => UsersActive.Create(x))
            .HasColumnName("active")
            .IsRequired();

        builder.Property(x => x.CreateDate)
            .HasConversion(
                x => x.Value,
                x => UsersCreateDate.Create(x))
            .HasColumnName("create_date")
            .IsRequired();

        builder.Property(x => x.FinishDate)
            .HasConversion(
                x => x.Value,
                x => UsersFinishDate.Create(x))
            .HasColumnName("finish_date");

        builder.Property(x => x.RoleId)
            .HasConversion(
                x => x.Value,
                x => UsersrolId.Create(x))
            .HasColumnName("role_id")
            .IsRequired();

        builder.HasIndex(x => x.Mail)
            .IsUnique();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}