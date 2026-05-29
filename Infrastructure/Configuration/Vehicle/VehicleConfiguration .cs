using Domain.Entities.Vehicle;
using Domain.ValueObject.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Vehicles;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ClientId)
            .HasConversion(
                x => x.Value,
                x => VehicleClientId.Create(x))
            .HasColumnName("client_id")
            .IsRequired();

        builder.Property(x => x.ModelId)
            .HasConversion(
                x => x.Value,
                x => VehicleModelId.Create(x))
            .HasColumnName("model_id")
            .IsRequired();

        builder.Property(x => x.Vin)
            .HasConversion(
                x => x.Value,
                x => VehicleVin.Create(x))
            .HasColumnName("vin")
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(x => x.Plate)
            .HasConversion(
                x => x.Value,
                x => VehiclePlate.Create(x))
            .HasColumnName("plate")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Year)
            .HasConversion(
                x => x.Value,
                x => VehicleYear.Create(x))
            .HasColumnName("year")
            .IsRequired();

        builder.Property(x => x.Color)
            .HasConversion(
                x => x.Value,
                x => VehicleColor.Create(x))
            .HasColumnName("color")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => VehicleActive.Create(x))
            .HasColumnName("active")
            .IsRequired();

        builder.HasIndex(x => x.Vin)
            .IsUnique();

        builder.HasIndex(x => x.Plate)
            .IsUnique();
    }
}