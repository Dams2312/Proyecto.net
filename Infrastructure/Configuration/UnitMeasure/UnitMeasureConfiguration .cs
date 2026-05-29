using Domain.Entities.UnitMeasure;
using Domain.ValueObject.UnitMeasure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.UnitMeasures;

public sealed class UnitMeasureConfiguration : IEntityTypeConfiguration<UnitMeasure>
{
    public void Configure(EntityTypeBuilder<UnitMeasure> builder)
    {
        builder.ToTable("UnitMeasure");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => UnitMeasureName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Abbreviation)
            .HasConversion(
                x => x.Value,
                x => UnitMeasureAbbreviation.Create(x))
            .HasColumnName("abbreviation")
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => x.Abbreviation)
            .IsUnique();
    }
}