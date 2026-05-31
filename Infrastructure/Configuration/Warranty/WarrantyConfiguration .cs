using Domain.ValueObject.Warranty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Warranty;

public sealed class WarrantyConfiguration : IEntityTypeConfiguration<Domain.Entities.Warranty.Warranty>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Warranty.Warranty> builder)
    {
        builder.ToTable("garantia");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.FechaInicio)
            .HasConversion(
                x => x.Value,
                x => WarrantyFechaInicio.Create(x))
            .HasColumnName("fecha_inicio")
            .IsRequired();

        builder.Property(x => x.FechaVencimiento)
            .HasConversion(
                x => x.Value,
                x => WarrantyFechaVencimiento.Create(x))
            .HasColumnName("fecha_vencimiento")
            .IsRequired();

        builder.Property(x => x.Condiciones)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : WarrantyCondiciones.Create(x))
            .HasColumnName("condiciones");

        builder.Property(x => x.Estado)
            .HasConversion(
                x => x.Value,
                x => WarrantyEstado.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        // OrderId, ServiceTypeId y MechanicId no existen en la entidad
        // El SQL las tiene pero el dominio no las expone — no se mapean
    }
}