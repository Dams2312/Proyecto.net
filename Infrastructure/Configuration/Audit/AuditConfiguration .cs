using Domain.Entities.Audit;
using Domain.ValueObject.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Audits;

public sealed class AuditConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("Audit");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Entidad)
            .HasConversion(
                x => x.Value,
                x => AuditEntidad.Create(x))
            .HasColumnName("entidad")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Fecha)
            .HasConversion(
                x => x.Value,
                x => AuditFecha.Create(x))
            .HasColumnName("fecha")
            .IsRequired();

        builder.Property(x => x.TipoAccion)
            .HasConversion(
                x => x.Value,
                x => AuditTipoAccion.Create(x))
            .HasColumnName("tipo_accion")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.DatosAnteriores)
            .HasConversion(
                x => x.Value,
                x => AuditDatosAnteriores.Create(x))
            .HasColumnName("datos_anteriores");

        builder.Property(x => x.DatosNuevos)
            .HasConversion(
                x => x.Value,
                x => AuditDatosNuevos.Create(x))
            .HasColumnName("datos_nuevos");

        builder.Property(x => x.IpOrigen)
            .HasConversion(
                x => x.Value,
                x => AuditIpOrigen.Create(x))
            .HasColumnName("ip_origen")
            .HasMaxLength(45);
    }
}