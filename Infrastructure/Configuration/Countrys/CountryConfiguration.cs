using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueObject.Country;
using Domain.Entities.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Countrys;

public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");

        // Primary Key
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Name
        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => CountryName.Create(x))
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        // Code
        builder.Property(x => x.Code)
            .HasConversion(
                x => x.Value,
                x => CountryCode.Create(x))
            .HasColumnName("code")
            .HasMaxLength(3)
            .IsRequired();

        // Unique
        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}
