using Domain.Entities.MileageHistory;
using Domain.ValueObject.MileageHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.MileageHistories;

public sealed class MileageHistoryConfiguration : IEntityTypeConfiguration<MileageHistory>
{
    public void Configure(EntityTypeBuilder<MileageHistory> builder)
    {
        builder.ToTable("MileageHistory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasConversion(
                x => x.Value,
                x => MileageHistoryVehicleId.Create(x))
            .HasColumnName("vehicle_id")
            .IsRequired();

        builder.Property(x => x.Kilometraje)
            .HasConversion(
                x => x.Value,
                x => MileageHistoryKilometraje.Create(x))
            .HasColumnName("kilometraje")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasConversion(
                x => x.Value,
                x => MileageHistoryDate.Create(x))
            .HasColumnName("date")
            .IsRequired();

        builder.Property(x => x.Source)
            .HasConversion(
                x => x.Value,
                x => MileageHistorySource.Create(x))
            .HasColumnName("source")
            .HasMaxLength(30)
            .IsRequired();
    }
}