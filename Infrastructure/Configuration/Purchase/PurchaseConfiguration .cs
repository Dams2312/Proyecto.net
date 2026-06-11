using Domain.ValueObject.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Purchase;

public sealed class PurchaseConfiguration : IEntityTypeConfiguration<Domain.Entities.Purchase.Purchase>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Purchase.Purchase> builder)
    {
        builder.ToTable("compra");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.SupplierId)
            .HasConversion(x => x.Value, x => PurchaseSupplierId.Create(x))
            .HasColumnName("proveedor_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => PurchaseUserId.Create(x))
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasConversion(x => x.Value, x => PurchaseDate.Create(x))
            .HasColumnName("fecha_compra")
            .IsRequired();

        builder.Property(x => x.Total)
            .HasConversion(x => x.Value, x => PurchaseTotal.Create(x))
            .HasColumnName("total")
            .HasColumnType("decimal(14,2)")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(x => x.Value, x => PurchaseStatus.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Observations)
            .HasConversion(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<PurchaseObservations?, string?>(
                x => x == null ? (string?)null : x.Value,
                x => x == null ? null : PurchaseObservations.Create(x)))
            .HasColumnName("observaciones")
            .HasColumnType("text");

    }
}
