using Domain.Entities.OrderService;
using Domain.ValueObject.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderServices;

public sealed class OrderServiceConfiguration : IEntityTypeConfiguration<OrderService>
{
    public void Configure(EntityTypeBuilder<OrderService> builder)
    {
        builder.ToTable("OrderService");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasConversion(
                x => x.Value,
                x => OrderServiceVehicleId.Create(x))
            .HasColumnName("vehicle_id")
            .IsRequired();

        builder.Property(x => x.ReceptionistId)
            .HasConversion(
                x => x.Value,
                x => OrderServiceReceptionistId.Create(x))
            .HasColumnName("receptionist_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasConversion(
                x => x.Value,
                x => OrderServiceStatusId.Create(x))
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.KilometrajeIngreso)
            .HasConversion(
                x => x.Value,
                x => OrderServiceKilometrajeIngreso.Create(x))
            .HasColumnName("kilometraje_ingreso")
            .IsRequired();

        builder.Property(x => x.FechaIngreso)
            .HasConversion(
                x => x.Value,
                x => OrderServiceFechaIngreso.Create(x))
            .HasColumnName("fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.FechaEstimada)
            .HasConversion(
                x => x!.Value,
                x => OrderServiceFechaEstimada.Create(x))
            .HasColumnName("fecha_estimada");

        builder.Property(x => x.FechaEntregaReal)
            .HasConversion(
                x => x!.Value,
                x => OrderServiceFechaEntregaReal.Create(x))
            .HasColumnName("fecha_entrega_real");

        builder.Property(x => x.AppointmentId)
            .HasConversion(
                x => x!.Value,
                x => OrderServiceAppointmentId.Create(x))
            .HasColumnName("appointment_id");

        builder.Property(x => x.Observaciones)
            .HasConversion(
                x => x.Value,
                x => OrderServiceObservaciones.Create(x))
            .HasColumnName("observaciones")
            .HasMaxLength(500);
    }
}