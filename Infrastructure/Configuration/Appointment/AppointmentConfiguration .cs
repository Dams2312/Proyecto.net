using Domain.ValueObject.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Appointment;

public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Appointment.Appointment>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Appointment.Appointment> builder)
    {
        builder.ToTable("cita");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasColumnName("vehiculo_id")
            .IsRequired();

        builder.Property(x => x.ReceptionistId)
            .HasColumnName("recepcionista_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasColumnName("tipo_servicio_id")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasConversion(
                x => x.Value,
                x => AppointmentDate.Create(x))
            .HasColumnName("fecha_cita")
            .IsRequired();

        builder.Property(x => x.StartTime)
            .HasConversion(
                x => x.Value,
                x => AppointmentStartTime.Create(x))
            .HasColumnName("hora_inicio")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasConversion(
                x => x.Value,
                x => AppointmentEndTime.Create(x))
            .HasColumnName("hora_fin")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Value,
                x => AppointmentStatus.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Observations)
            .HasConversion(
                x => x.Value,
                x => AppointmentObservations.Create(x))
            .HasColumnName("observaciones")
            .HasColumnType("text");

        // FK → vehiculo
        builder.HasOne<Domain.Entities.Vehicle.Vehicle>()
            .WithMany()
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK → usuario (recepcionista)
        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey(x => x.ReceptionistId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK → tipo_servicio
        builder.HasOne<Domain.Entities.ServiceType.ServiceType>()
            .WithMany()
            .HasForeignKey(x => x.ServiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.VehicleId).HasDatabaseName("idx_cita_vehiculo");
        builder.HasIndex(x => x.Date).HasDatabaseName("idx_cita_fecha");
    }
}