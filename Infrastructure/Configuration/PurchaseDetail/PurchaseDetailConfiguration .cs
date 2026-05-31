using Domain.ValueObject.PurchaseDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.PurchaseDetail;

public sealed class PurchaseDetailConfiguration : IEntityTypeConfiguration<Domain.Entities.PurchaseDetail.PurchaseDetail>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.PurchaseDetail.PurchaseDetail> builder)
    {
        builder.ToTable("detalle_compra");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PurchaseId)
            .HasConversion(x => x.Value, x => PurchaseDetailPurchaseId.Create(x))
            .HasColumnName("compra_id")
            .IsRequired();

        builder.Property(x => x.SparePartId)
            .HasConversion(x => x.Value, x => PurchaseDetailSparePartId.Create(x))
            .HasColumnName("repuesto_id")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasConversion(x => x.Value, x => PurchaseDetailQuantity.Create(x))
            .HasColumnName("cantidad")
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasConversion(x => x.Value, x => PurchaseDetailUnitPrice.Create(x))
            .HasColumnName("precio_unitario")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.HasIndex(x => new { x.PurchaseId, x.SparePartId }).IsUnique().HasDatabaseName("uq_dc_compra_repuesto");

        builder.HasOne<Domain.Entities.Purchase.Purchase>()
            .WithMany()
            .HasForeignKey("compra_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.SparePart.SparePart>()
            .WithMany()
            .HasForeignKey("repuesto_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}