using Domain.Entities.OrderServiceType;
using Domain.ValueObject.OrderServiceType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderServiceTypes;

public sealed class OrderServiceTypeConfiguration : IEntityTypeConfiguration<OrderServiceType>
{
    public void Configure(EntityTypeBuilder<OrderServiceType> builder)
    {
        builder.ToTable("OrderServiceType");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => OrderServiceTypeOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasConversion(
                x => x.Value,
                x => OrderServiceTypeServiceTypeId.Create(x))
            .HasColumnName("service_type_id")
            .IsRequired();
    }
}