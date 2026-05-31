using Domain.ValueObject.UnitMeasure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.UnitMeasure;

public sealed class UnitMeasureConfiguration : IEntityTypeConfiguration<Domain.Entities.UnitMeasure.UnitMeasure>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.UnitMeasure.UnitMeasure> builder)
    {
        builder.ToTable("unidad_medida");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => UnitMeasureName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Abbreviation)
            .HasConversion(
                x => x.Value,
                x => UnitMeasureAbbreviation.Create(x))
            .HasColumnName("abreviatura")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.Abbreviation).IsUnique();
    }
}