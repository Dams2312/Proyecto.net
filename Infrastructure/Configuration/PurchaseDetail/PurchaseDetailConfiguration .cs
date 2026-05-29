using Domain.Entities.PurchaseDetail;
using Domain.ValueObject.PurchaseDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.PurchaseDetails;

public sealed class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
{
    public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
    {
        builder.ToTable("PurchaseDetail");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PurchaseId)
            .HasConversion(
                x => x.Value,
                x => PurchaseDetailPurchaseId.Create(x))
            .HasColumnName("purchase_id")
            .IsRequired();

        builder.Property(x => x.SparePartId)
            .HasConversion(
                x => x.Value,
                x => PurchaseDetailSparePartId.Create(x))
            .HasColumnName("spare_part_id")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(
                x => x.Value,
                x => PurchaseDetailQuantity.Create(x))
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasConversion(
                x => x.Value,
                x => PurchaseDetailUnitPrice.Create(x))
            .HasColumnName("unit_price")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}