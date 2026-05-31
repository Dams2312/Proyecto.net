using Domain.ValueObject.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Audit;

public sealed class AuditConfiguration : IEntityTypeConfiguration<Domain.Entities.Audit.Audit>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Audit.Audit> builder)
    {
        builder.ToTable("auditoria");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("usuario_id")
            .IsRequired();

        // entidad_id en la BD es INT (PK del registro afectado), no FK navegable
        builder.Property(x => x.EntidadId)
            .HasColumnName("entidad_id")
            .IsRequired();

        builder.Property(x => x.Entidad)
            .HasConversion(
                x => x.Value,
                x => AuditEntidad.Create(x))
            .HasColumnName("entidad")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.TipoAccion)
            .HasConversion(
                x => x.Value,
                x => AuditTipoAccion.Create(x))
            .HasColumnName("tipo_accion")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.DatosAnteriores)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : AuditDatosAnteriores.Create(x))
            .HasColumnName("datos_anteriores")
            .HasColumnType("json");

        builder.Property(x => x.DatosNuevos)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : AuditDatosNuevos.Create(x))
            .HasColumnName("datos_nuevos")
            .HasColumnType("json");

        builder.Property(x => x.IpOrigen)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : AuditIpOrigen.Create(x))
            .HasColumnName("ip_origen")
            .HasMaxLength(45);

        builder.Property(x => x.Fecha)
            .HasConversion(
                x => x.Value,
                x => AuditFecha.Create(x))
            .HasColumnName("fecha")
            .IsRequired();

        // FK → usuario
        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.UserId).HasDatabaseName("idx_audit_usuario");
        builder.HasIndex(x => x.Fecha).HasDatabaseName("idx_audit_fecha");
    }
}