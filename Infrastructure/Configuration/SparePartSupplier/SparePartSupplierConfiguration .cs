using Domain.ValueObject.SparePartSupplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SparePartSupplier;

public sealed class SparePartSupplierConfiguration : IEntityTypeConfiguration<Domain.Entities.SparePartSupplier.SparePartSupplier>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.SparePartSupplier.SparePartSupplier> builder)
    {
        builder.ToTable("repuesto_proveedor");

        builder.HasKey(x => new { x.SparePartId, x.SupplierId });

        builder.Property(x => x.SparePartId)
            .HasConversion(x => x.Value, x => SparePartSupplierSparePartId.Create(x))
            .HasColumnName("repuesto_id")
            .IsRequired();

        builder.Property(x => x.SupplierId)
            .HasConversion(x => x.Value, x => SparePartSupplierSupplierId.Create(x))
            .HasColumnName("proveedor_id")
            .IsRequired();

        builder.Property(x => x.PurchasePrice)
            .HasConversion(x => x.Value, x => SparePartSupplierPurchasePrice.Create(x))
            .HasColumnName("precio_compra")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.Principal)
            .HasConversion(x => x.Value, x => SparePartSupplierPrincipal.Create(x))
            .HasColumnName("principal")
            .IsRequired();

        builder.HasOne<Domain.Entities.SparePart.SparePart>()
            .WithMany()
            .HasForeignKey("repuesto_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Supplier.Supplier>()
            .WithMany()
            .HasForeignKey("proveedor_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}