using Domain.Entities.Warranty;
using Domain.ValueObject.Warranty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Warranties;

public sealed class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
{
    public void Configure(EntityTypeBuilder<Warranty> builder)
    {
        builder.ToTable("Warranty");

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

        builder.Property(x => x.Estado)
            .HasConversion(
                x => x.Value,
                x => WarrantyEstado.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Condiciones)
            .HasConversion(
                x => x.Value,
                x => WarrantyCondiciones.Create(x))
            .HasColumnName("condiciones")
            .HasMaxLength(1000);
    }
}