using Domain.ValueObject.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderService;

public sealed class OrderServiceConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderService.OrderService>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderService.OrderService> builder)
    {
        builder.ToTable("orden_servicio");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasConversion(x => x.Value, x => OrderServiceVehicleId.Create(x))
            .HasColumnName("vehiculo_id")
            .IsRequired();

        builder.Property(x => x.ReceptionistId)
            .HasConversion(x => x.Value, x => OrderServiceReceptionistId.Create(x))
            .HasColumnName("recepcionista_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasConversion(x => x.Value, x => OrderServiceStatusId.Create(x))
            .HasColumnName("estado_id")
            .IsRequired();

        builder.Property(x => x.AppointmentId)
            .HasColumnName("cita_id");

        builder.Property(x => x.KilometrajeIngreso)
            .HasConversion(x => x.Value, x => OrderServiceKilometrajeIngreso.Create(x))
            .HasColumnName("kilometraje_ingreso")
            .IsRequired();

        builder.Property(x => x.FechaIngreso)
            .HasConversion(x => x.Value, x => OrderServiceFechaIngreso.Create(x))
            .HasColumnName("fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.FechaEstimada)
            .HasConversion(
                x => x == null ? (DateOnly?)null : x.Value,
                x => x == null ? null : OrderServiceFechaEstimada.Create(x))
            .HasColumnName("fecha_estimada");

        builder.Property(x => x.FechaEntregaReal)
            .HasConversion(
                x => x == null ? (DateOnly?)null : x.Value,
                x => x == null ? null : OrderServiceFechaEntregaReal.Create(x))
            .HasColumnName("fecha_entrega_real");

        builder.Property(x => x.Observaciones)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : OrderServiceObservaciones.Create(x))
            .HasColumnName("observaciones")
            .HasColumnType("text");

        builder.HasIndex(x => x.VehicleId).HasDatabaseName("idx_orden_vehiculo");
        builder.HasIndex(x => x.StatusId).HasDatabaseName("idx_orden_estado");

        builder.HasOne<Domain.Entities.Vehicle.Vehicle>()
            .WithMany()
            .HasForeignKey("vehiculo_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey("recepcionista_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.OrderStatus.OrderStatus>()
            .WithMany()
            .HasForeignKey("estado_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Appointment.Appointment>()
            .WithMany()
            .HasForeignKey(x => x.AppointmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}