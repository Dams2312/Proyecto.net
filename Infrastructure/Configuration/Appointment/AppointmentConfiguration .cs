using Domain.Entities.Appointment;
using Domain.ValueObject.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Appointments;

public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointment");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VehicleId)
            .HasConversion(
                x => x.Value,
                x => AppointmentVehicleId.Create(x))
            .HasColumnName("vehicle_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasConversion(
                x => x.Value,
                x => AppointmentServiceTypeId.Create(x))
            .HasColumnName("service_type_id")
            .IsRequired();

        builder.Property(x => x.ReceptionistId)
            .HasConversion(
                x => x.Value,
                x => AppointmentReceptionistId.Create(x))
            .HasColumnName("receptionist_id")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasConversion(
                x => x.Value,
                x => AppointmentDate.Create(x))
            .HasColumnName("date")
            .IsRequired();

        builder.Property(x => x.StartTime)
            .HasConversion(
                x => x.Value,
                x => AppointmentStartTime.Create(x))
            .HasColumnName("start_time")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasConversion(
                x => x.Value,
                x => AppointmentEndTime.Create(x))
            .HasColumnName("end_time")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Value,
                x => AppointmentStatus.Create(x))
            .HasColumnName("status")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Observations)
            .HasConversion(
                x => x.Value,
                x => AppointmentObservations.Create(x))
            .HasColumnName("observations")
            .HasMaxLength(500);
    }
}