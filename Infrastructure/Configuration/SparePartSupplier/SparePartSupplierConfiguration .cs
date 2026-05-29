using Domain.Entities.SparePartSupplier;
using Domain.ValueObject.SparePartSupplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.SparePartSuppliers;

public sealed class SparePartSupplierConfiguration : IEntityTypeConfiguration<SparePartSupplier>
{
    public void Configure(EntityTypeBuilder<SparePartSupplier> builder)
    {
        builder.ToTable("SparePartSupplier");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.SparePartId)
            .HasConversion(
                x => x.Value,
                x => SparePartSupplierSparePartId.Create(x))
            .HasColumnName("spare_part_id")
            .IsRequired();

        builder.Property(x => x.SupplierId)
            .HasConversion(
                x => x.Value,
                x => SparePartSupplierSupplierId.Create(x))
            .HasColumnName("supplier_id")
            .IsRequired();

        builder.Property(x => x.PurchasePrice)
            .HasConversion(
                x => x.Value,
                x => SparePartSupplierPurchasePrice.Create(x))
            .HasColumnName("purchase_price")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Principal)
            .HasConversion(
                x => x.Value,
                x => SparePartSupplierPrincipal.Create(x))
            .HasColumnName("principal")
            .IsRequired();
    }
}