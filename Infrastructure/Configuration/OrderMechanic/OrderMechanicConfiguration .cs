using Domain.Entities.OrderMechanic;
using Domain.ValueObject.OrderMechanic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderMechanics;

public sealed class OrderMechanicConfiguration : IEntityTypeConfiguration<OrderMechanic>
{
    public void Configure(EntityTypeBuilder<OrderMechanic> builder)
    {
        builder.ToTable("OrderMechanic");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => OrderMechanicOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.MechanicId)
            .HasConversion(
                x => x.Value,
                x => OrderMechanicMechanicId.Create(x))
            .HasColumnName("mechanic_id")
            .IsRequired();

        builder.Property(x => x.FechaAsignacion)
            .HasConversion(
                x => x.Value,
                x => OrderMechanicFechaAsignacion.Create(x))
            .HasColumnName("fecha_asignacion")
            .IsRequired();
    }
}