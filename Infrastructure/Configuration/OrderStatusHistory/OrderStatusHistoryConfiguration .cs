using Domain.Entities.OrderStatusHistory;
using Domain.ValueObject.OrderStatusHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderStatusHistories;

public sealed class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
    {
        builder.ToTable("OrderStatusHistory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => OrderStatusHistoryOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasConversion(
                x => x.Value,
                x => OrderStatusHistoryStatusId.Create(x))
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                x => x.Value,
                x => OrderStatusHistoryUserId.Create(x))
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.FechaCambio)
            .HasConversion(
                x => x.Value,
                x => OrderStatusHistoryFechaCambio.Create(x))
            .HasColumnName("fecha_cambio")
            .IsRequired();
    }
}