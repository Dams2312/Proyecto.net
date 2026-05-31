using Domain.ValueObject.OrderStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderStatus;

public sealed class OrderStatusConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderStatus.OrderStatus>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderStatus.OrderStatus> builder)
    {
        builder.ToTable("estado_orden");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => OrderStatusName.Create(x))
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                x => x == null ? null : x.Value,
                x => x == null ? null : OrderStatusDescription.Create(x))
            .HasColumnName("descripcion")
            .HasColumnType("text");

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("uq_estado_orden_nombre");
    }
}