using Domain.Entities.SpareCategory;
using Domain.ValueObject.SpareCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SpareCategories;

public sealed class SpareCategoryConfiguration : IEntityTypeConfiguration<SpareCategory>
{
    public void Configure(EntityTypeBuilder<SpareCategory> builder)
    {
        builder.ToTable("SpareCategory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => SpareCategoryName.Create(x))
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => SpareCategoryDescription.Create(x))
            .HasColumnName("description")
            .HasMaxLength(300);

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}