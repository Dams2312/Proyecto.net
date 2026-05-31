using Domain.ValueObject.OrderServiceType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderServiceType;

public sealed class OrderServiceTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderServiceType.OrderServiceType>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderServiceType.OrderServiceType> builder)
    {
        builder.ToTable("orden_tipo_servicio");

        builder.Ignore(x => x.Id);
        builder.HasKey(x => new { x.OrderId, x.ServiceTypeId });

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => OrderServiceTypeOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasConversion(x => x.Value, x => OrderServiceTypeServiceTypeId.Create(x))
            .HasColumnName("tipo_servicio_id")
            .IsRequired();

        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey("orden_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Entities.ServiceType.ServiceType>()
            .WithMany()
            .HasForeignKey("tipo_servicio_id")
            .HasPrincipalKey("Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}