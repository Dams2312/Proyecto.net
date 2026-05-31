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

        // FKs COMO GUID, NO NECESITAN HasConversion
        builder.Property(x => x.OrderId)
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasColumnName("tipo_servicio_id")
            .IsRequired();

        builder.Property(x => x.MechanicId)
            .HasColumnName("mecanico_id")
            .IsRequired();

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
            .HasColumnName("condiciones")
            .HasColumnType("text");

        builder.Property(x => x.Estado)
            .HasConversion(
                x => x.Value,
                x => WarrantyEstado.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.OrderId).HasDatabaseName("idx_garantia_orden");

        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.ServiceType.ServiceType>()
            .WithMany()
            .HasForeignKey(x => x.ServiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey(x => x.MechanicId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}