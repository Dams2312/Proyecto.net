using Domain.Entities.SparePart;
using Domain.ValueObject.SparePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SpareParts;

public sealed class SparePartConfiguration : IEntityTypeConfiguration<SparePart>
{
    public void Configure(EntityTypeBuilder<SparePart> builder)
    {
        builder.ToTable("SparePart");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .HasConversion(
                x => x.Value,
                x => SparePartCode.Create(x))
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => SparePartDescription.Create(x))
            .HasColumnName("description")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.PrecioUnitario)
            .HasConversion(
                x => x.Value,
                x => SparePartPrecioUnitario.Create(x))
            .HasColumnName("precio_unitario")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.StockActual)
            .HasConversion(
                x => x.Value,
                x => SparePartStockActual.Create(x))
            .HasColumnName("stock_actual")
            .IsRequired();

        builder.Property(x => x.StockMinimo)
            .HasConversion(
                x => x.Value,
                x => SparePartStockMinimo.Create(x))
            .HasColumnName("stock_minimo")
            .IsRequired();

        builder.Property(x => x.CategoryId)
            .HasConversion(
                x => x.Value,
                x => SparePartCategoryId.Create(x))
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(x => x.UnitId)
            .HasConversion(
                x => x.Value,
                x => SparePartUnitId.Create(x))
            .HasColumnName("unit_id")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => SparePartActive.Create(x))
            .HasColumnName("active")
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}