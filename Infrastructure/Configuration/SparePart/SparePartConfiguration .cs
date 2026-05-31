using Domain.ValueObject.SparePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SparePart;

public sealed class SparePartConfiguration : IEntityTypeConfiguration<Domain.Entities.SparePart.SparePart>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.SparePart.SparePart> builder)
    {
        builder.ToTable("repuesto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CategoryId)
            .HasConversion(x => x.Value, x => SparePartCategoryId.Create(x))
            .HasColumnName("categoria_id")
            .IsRequired();

        builder.Property(x => x.UnitId)
            .HasConversion(x => x.Value, x => SparePartUnitId.Create(x))
            .HasColumnName("unidad_id")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasConversion(x => x.Value, x => SparePartCode.Create(x))
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, x => SparePartDescription.Create(x))
            .HasColumnName("descripcion")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.StockActual)
            .HasConversion(x => x.Value, x => SparePartStockActual.Create(x))
            .HasColumnName("stock_actual")
            .IsRequired();

        builder.Property(x => x.StockMinimo)
            .HasConversion(x => x.Value, x => SparePartStockMinimo.Create(x))
            .HasColumnName("stock_minimo")
            .IsRequired();

        builder.Property(x => x.PrecioUnitario)
            .HasConversion(x => x.Value, x => SparePartPrecioUnitario.Create(x))
            .HasColumnName("precio_unitario")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(x => x.Value, x => SparePartActive.Create(x))
            .HasColumnName("activo")
            .IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.CategoryId);

        builder.HasOne<Domain.Entities.SpareCategory.SpareCategory>()
            .WithMany()
            .HasForeignKey("categoria_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.UnitMeasure.UnitMeasure>()
            .WithMany()
            .HasForeignKey("unidad_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}