using Domain.ValueObject.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Role;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Domain.Entities.Roles.Role>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Roles.Role> builder)
    {
        builder.ToTable("rol");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => RoleName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => RoleDescription.Create(x))
            .HasColumnName("descripcion");

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_rol_nombre");
    }
}