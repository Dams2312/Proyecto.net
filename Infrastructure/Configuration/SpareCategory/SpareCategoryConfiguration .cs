using Domain.ValueObject.SpareCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SpareCategory;

public sealed class SpareCategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.SpareCategory.SpareCategory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.SpareCategory.SpareCategory> builder)
    {
        builder.ToTable("categoria_repuesto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => SpareCategoryName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => SpareCategoryDescription.Create(x))
            .HasColumnName("descripcion")
            .HasColumnType("text");

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_categoria_repuesto_nombre");
    }
}