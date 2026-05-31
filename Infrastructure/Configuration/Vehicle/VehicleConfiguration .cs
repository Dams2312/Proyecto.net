using Domain.ValueObject.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Vehicle;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Domain.Entities.Vehicle.Vehicle>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Vehicle.Vehicle> builder)
    {
        builder.ToTable("vehiculo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ClientId)
            .HasColumnName("cliente_id")
            .IsRequired();

        builder.Property(x => x.ModelId)
            .HasColumnName("modelo_id")
            .IsRequired();

        builder.Property(x => x.Vin)
            .HasConversion(
                x => x.Value,
                x => VehicleVin.Create(x))
            .HasColumnName("vin")
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(x => x.Year)
            .HasConversion(
                x => x.Value,
                x => VehicleYear.Create(x))
            .HasColumnName("anio")
            .IsRequired();

        builder.Property(x => x.Plate)
            .HasConversion(
                x => x.Value,
                x => VehiclePlate.Create(x))
            .HasColumnName("placa")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Color)
            .HasConversion(
                x => x.Value,
                x => VehicleColor.Create(x))
            .HasColumnName("color")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Active)
            .HasConversion(
                x => x.Value,
                x => VehicleActive.Create(x))
            .HasColumnName("activo")
            .IsRequired();

        builder.HasIndex(x => x.Vin)
            .IsUnique()
            .HasDatabaseName("uq_vehiculo_vin");

        builder.HasIndex(x => x.Plate)
            .IsUnique()
            .HasDatabaseName("uq_vehiculo_placa");

        builder.HasOne<Domain.Entities.Customers.Customer>()
            .WithMany()
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Vehiclemodel.VehicleModel>()
            .WithMany()
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}