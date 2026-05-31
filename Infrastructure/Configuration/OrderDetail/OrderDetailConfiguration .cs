using Domain.ValueObject.OrderDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderDetail;

public sealed class OrderDetailConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderDetail.OrderDetail>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderDetail.OrderDetail> builder)
    {
        builder.ToTable("detalle_orden");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => OrderDetailOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.SparePartId)
            .HasConversion(x => x.Value, x => OrderDetailSparePartId.Create(x))
            .HasColumnName("repuesto_id")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(x => x.Value, x => OrderDetailQuantity.Create(x))
            .HasColumnName("cantidad")
            .IsRequired();

        builder.Property(x => x.PriceSnapshot)
            .HasConversion(x => x.Value, x => OrderDetailPriceSnapshot.Create(x))
            .HasColumnName("precio_snapshot")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.HasIndex(x => new { x.OrderId, x.SparePartId }).IsUnique().HasDatabaseName("uq_do_orden_repuesto");
        builder.HasIndex(x => x.OrderId).HasDatabaseName("idx_do_orden");

        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey("orden_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.SparePart.SparePart>()
            .WithMany()
            .HasForeignKey("repuesto_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}