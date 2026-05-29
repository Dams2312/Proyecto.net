using Domain.Entities.Citys;
using Domain.ValueObject.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Citys;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => CityName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Code)
            .HasConversion(
                x => x.Value,
                x => CityCode.Create(x))
            .HasColumnName("code")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.CountryId)
            .HasConversion(
                x => x.Value,
                x => CityCountryId.Create(x))
            .HasColumnName("country_id")
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}