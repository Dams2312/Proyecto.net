using Domain.Entities.Purchase;
using Domain.ValueObject.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Purchases;

public sealed class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchase");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Date)
            .HasConversion(
                x => x.Value,
                x => PurchaseDate.Create(x))
            .HasColumnName("date")
            .IsRequired();

        builder.Property(x => x.SupplierId)
            .HasConversion(
                x => x.Value,
                x => PurchaseSupplierId.Create(x))
            .HasColumnName("supplier_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                x => x.Value,
                x => PurchaseUserId.Create(x))
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Value,
                x => PurchaseStatus.Create(x))
            .HasColumnName("status")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Observations)
            .HasConversion(
                x => x.Value,
                x => PurchaseObservations.Create(x))
            .HasColumnName("observations")
            .HasMaxLength(500);

        builder.Property(x => x.Total)
            .HasConversion(
                x => x.Value,
                x => PurchaseTotal.Create(x))
            .HasColumnName("total")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}