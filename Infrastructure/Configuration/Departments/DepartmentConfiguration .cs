using Domain.Entities.Departments;
using Domain.ValueObject.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Departments;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Department");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .HasConversion(
                x => x.Value,
                x => DepartmentCode.Create(x))
            .HasColumnName("code")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => DepartmentName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CountryId)
            .HasConversion(
                x => x.Value,
                x => DepartmentCountryId.Create(x))
            .HasColumnName("country_id")
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}