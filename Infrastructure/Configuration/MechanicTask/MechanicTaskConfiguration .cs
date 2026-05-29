using Domain.Entities.MechanicTask;
using Domain.ValueObject.MechanicTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.MechanicTasks;

public sealed class MechanicTaskConfiguration : IEntityTypeConfiguration<MechanicTask>
{
    public void Configure(EntityTypeBuilder<MechanicTask> builder)
    {
        builder.ToTable("MechanicTask");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.MechanicId)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskMechanicId.Create(x))
            .HasColumnName("mechanic_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskServiceTypeId.Create(x))
            .HasColumnName("service_type_id")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskDescription.Create(x))
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskStatus.Create(x))
            .HasColumnName("status")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.FechaInicio)
            .HasConversion(
                x => x!.Value,
                x => MechanicTaskFechaInicio.Create(x))
            .HasColumnName("fecha_inicio");

        builder.Property(x => x.FechaFin)
            .HasConversion(
                x => x!.Value,
                x => MechanicTaskFechaFin.Create(x))
            .HasColumnName("fecha_fin");

        builder.Property(x => x.HoursWorked)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskHoursWorked.Create(x))
            .HasColumnName("hours_worked")
            .HasPrecision(6, 2);

        builder.Property(x => x.HourlyCost)
            .HasConversion(
                x => x.Value,
                x => MechanicTaskHourlyCost.Create(x))
            .HasColumnName("hourly_cost")
            .HasPrecision(18, 2);
    }
}