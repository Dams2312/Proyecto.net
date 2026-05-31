using Domain.ValueObject.InventoryLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.InventoryLog;

public sealed class InventoryLogConfiguration : IEntityTypeConfiguration<Domain.Entities.InventoryLog.InventoryLog>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.InventoryLog.InventoryLog> builder)
    {
        builder.ToTable("log_inventario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // FKs directas como Guid
        builder.Property(x => x.SparePartId)
            .HasColumnName("repuesto_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("usuario_id")
            .IsRequired();

        // orden_id y compra_id son nullable en el SQL
        builder.Property(x => x.OrderId)
            .HasColumnName("orden_id");

        builder.Property(x => x.PurchaseId)
            .HasColumnName("compra_id");

        builder.Property(x => x.TypeMovement)
            .HasConversion(
                x => x.Value,
                x => InventoryLogTypeMovement.Create(x))
            .HasColumnName("tipo_movimiento")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(
                x => x.Value,
                x => InventoryLogQuantity.Create(x))
            .HasColumnName("cantidad")
            .IsRequired();

        builder.Property(x => x.StockResultante)
            .HasConversion(
                x => x.Value,
                x => InventoryLogStockResultante.Create(x))
            .HasColumnName("stock_resultante")
            .IsRequired();

        builder.Property(x => x.Fecha)
            .HasConversion(
                x => x.Value,
                x => InventoryLogFecha.Create(x))
            .HasColumnName("fecha")
            .IsRequired();

        builder.Property(x => x.Motivo)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : InventoryLogMotivo.Create(x))
            .HasColumnName("motivo")
            .HasColumnType("text");

        builder.HasIndex(x => x.SparePartId).HasDatabaseName("idx_log_repuesto");
        builder.HasIndex(x => x.Fecha).HasDatabaseName("idx_log_fecha");

        // FK → repuesto
        builder.HasOne<Domain.Entities.SparePart.SparePart>()
            .WithMany()
            .HasForeignKey(x => x.SparePartId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK → usuario
        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK nullable → orden_servicio
        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // FK nullable → compra
        builder.HasOne<Domain.Entities.Purchase.Purchase>()
            .WithMany()
            .HasForeignKey(x => x.PurchaseId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}