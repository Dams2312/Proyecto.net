using Domain.Entities.OrderDetail;
using Domain.ValueObject.OrderDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderDetails;

public sealed class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetail");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => OrderDetailOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.SparePartId)
            .HasConversion(
                x => x.Value,
                x => OrderDetailSparePartId.Create(x))
            .HasColumnName("spare_part_id")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(
                x => x.Value,
                x => OrderDetailQuantity.Create(x))
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.PriceSnapshot)
            .HasConversion(
                x => x.Value,
                x => OrderDetailPriceSnapshot.Create(x))
            .HasColumnName("price_snapshot")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}