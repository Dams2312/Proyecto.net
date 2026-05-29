using Domain.Entities.InventoryLog;
using Domain.ValueObject.InventoryLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.InventoryLogs;

public sealed class InventoryLogConfiguration : IEntityTypeConfiguration<InventoryLog>
{
    public void Configure(EntityTypeBuilder<InventoryLog> builder)
    {
        builder.ToTable("InventoryLog");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.SparePartId)
            .HasConversion(
                x => x.Value,
                x => InventoryLogSparePartId.Create(x))
            .HasColumnName("spare_part_id")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(
                x => x.Value,
                x => InventoryLogQuantity.Create(x))
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.StockResultante)
            .HasConversion(
                x => x.Value,
                x => InventoryLogStockResultante.Create(x))
            .HasColumnName("stock_resultante")
            .IsRequired();

        builder.Property(x => x.TypeMovement)
            .HasConversion(
                x => x.Value,
                x => InventoryLogTypeMovement.Create(x))
            .HasColumnName("type_movement")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                x => x.Value,
                x => InventoryLogUserId.Create(x))
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.Fecha)
            .HasConversion(
                x => x.Value,
                x => InventoryLogFecha.Create(x))
            .HasColumnName("fecha")
            .IsRequired();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => InventoryLogOrderId.Create(x))
            .HasColumnName("order_id");

        builder.Property(x => x.PurchaseId)
            .HasConversion(
                x => x.Value,
                x => InventoryLogPurchaseId.Create(x))
            .HasColumnName("purchase_id");

        builder.Property(x => x.Motivo)
            .HasConversion(
                x => x.Value,
                x => InventoryLogMotivo.Create(x))
            .HasColumnName("motivo")
            .HasMaxLength(300);
    }
}