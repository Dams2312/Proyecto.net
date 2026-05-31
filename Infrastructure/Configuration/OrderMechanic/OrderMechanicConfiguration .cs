using Domain.ValueObject.OrderMechanic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderMechanic;

public sealed class OrderMechanicConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderMechanic.OrderMechanic>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderMechanic.OrderMechanic> builder)
    {
        builder.ToTable("orden_mecanico");

        builder.Ignore(x => x.Id);
        builder.HasKey(x => new { x.OrderId, x.MechanicId });

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => OrderMechanicOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.MechanicId)
            .HasConversion(x => x.Value, x => OrderMechanicMechanicId.Create(x))
            .HasColumnName("mecanico_id")
            .IsRequired();

        builder.Property(x => x.FechaAsignacion)
            .HasConversion(x => x.Value, x => OrderMechanicFechaAsignacion.Create(x))
            .HasColumnName("fecha_asignacion")
            .IsRequired();

        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey("orden_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey("mecanico_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}