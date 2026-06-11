using Domain.ValueObject.MechanicTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Configuration.MechanicTask;

public sealed class MechanicTaskConfiguration : IEntityTypeConfiguration<Domain.Entities.MechanicTask.MechanicTask>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.MechanicTask.MechanicTask> builder)
    {
        builder.ToTable("tarea_mecanico");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => MechanicTaskOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.MechanicId)
            .HasConversion(x => x.Value, x => MechanicTaskMechanicId.Create(x))
            .HasColumnName("mecanico_id")
            .IsRequired();

        var serviceTypeConverter = new ValueConverter<MechanicTaskServiceTypeId, Guid>(
            v => v.Value,
            v => MechanicTaskServiceTypeId.Create(v));

        builder.Property(x => x.ServiceTypeId)
            .HasConversion(serviceTypeConverter)
            .HasColumnName("tipo_servicio_id");

        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, x => MechanicTaskDescription.Create(x))
            .HasColumnName("descripcion")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.HoursWorked)
            .HasConversion(x => x.Value, x => MechanicTaskHoursWorked.Create(x))
            .HasColumnName("horas_trabajadas")
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(x => x.HourlyCost)
            .HasConversion(x => x.Value, x => MechanicTaskHourlyCost.Create(x))
            .HasColumnName("costo_hora")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(x => x.Value, x => MechanicTaskStatus.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        var fechaInicioConverter = new ValueConverter<MechanicTaskFechaInicio, DateTime?>(
            v => v.Value,
            v => MechanicTaskFechaInicio.Create(v));

        builder.Property(x => x.FechaInicio)
            .HasConversion(fechaInicioConverter)
            .HasColumnName("fecha_inicio");

        var fechaFinConverter = new ValueConverter<MechanicTaskFechaFin, DateTime?>(
            v => v.Value,
            v => MechanicTaskFechaFin.Create(v));

        builder.Property(x => x.FechaFin)
            .HasConversion(fechaFinConverter)
            .HasColumnName("fecha_fin");

        builder.HasIndex(x => x.OrderId).HasDatabaseName("idx_tarea_orden");
        builder.HasIndex(x => x.MechanicId).HasDatabaseName("idx_tarea_mecanico");

    }
}
