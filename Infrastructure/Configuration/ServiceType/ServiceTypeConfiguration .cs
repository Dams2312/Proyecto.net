using Domain.ValueObject.ServiceType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.ServiceType;

public sealed class ServiceTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.ServiceType.ServiceType>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ServiceType.ServiceType> builder)
    {
        builder.ToTable("tipo_servicio");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeDescription.Create(x))
            .HasColumnName("descripcion")
            .HasColumnType("text");

        builder.Property(x => x.EstimatedDays)
            .HasConversion(
                x => x.Value,
                x => ServiceTypeEstimatedDays.Create(x))
            .HasColumnName("dias_estimados")
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_tipo_servicio_nombre");
    }
}