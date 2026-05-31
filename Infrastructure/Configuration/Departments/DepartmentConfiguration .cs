using Domain.ValueObject.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Department;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Departments.Department>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Departments.Department> builder)
    {
        builder.ToTable("departamento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => DepartmentName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired();

        // codigo no existe en la tabla departamento del SQL → ignorar
        builder.Ignore(x => x.Code);

        // FK directa como Guid → pais_id
        builder.Property(x => x.CountryId)
            .HasColumnName("pais_id")
            .IsRequired();

        // FK → pais
        builder.HasOne<Domain.Entities.Countries.Country>()
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}