using Domain.ValueObject.MileageHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.MileageHistory;

public sealed class MileageHistoryConfiguration : IEntityTypeConfiguration<Domain.Entities.MileageHistory.MileageHistory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.MileageHistory.MileageHistory> builder)
    {
        builder.ToTable("historial_kilometraje");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasConversion(x => x.Value, x => MileageHistoryVehicleId.Create(x))
            .HasColumnName("vehiculo_id")
            .IsRequired();

        builder.Property(x => x.Kilometraje)
            .HasConversion(x => x.Value, x => MileageHistoryKilometraje.Create(x))
            .HasColumnName("kilometraje")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasConversion(x => x.Value, x => MileageHistoryDate.Create(x))
            .HasColumnName("fecha")
            .IsRequired();

        builder.Property(x => x.Source)
            .HasConversion(x => x.Value, x => MileageHistorySource.Create(x))
            .HasColumnName("fuente")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.VehicleId).HasDatabaseName("idx_hkm_vehiculo");

    }
}
