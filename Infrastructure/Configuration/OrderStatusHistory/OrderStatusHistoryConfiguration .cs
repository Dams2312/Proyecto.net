using Domain.ValueObject.OrderStatusHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.OrderStatusHistory;

public sealed class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderStatusHistory.OrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderStatusHistory.OrderStatusHistory> builder)
    {
        builder.ToTable("historial_estado_orden");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => OrderStatusHistoryOrderId.Create(x))
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasConversion(x => x.Value, x => OrderStatusHistoryStatusId.Create(x))
            .HasColumnName("estado_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => OrderStatusHistoryUserId.Create(x))
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(x => x.FechaCambio)
            .HasConversion(x => x.Value, x => OrderStatusHistoryFechaCambio.Create(x))
            .HasColumnName("fecha_cambio")
            .IsRequired();

        builder.HasIndex(x => x.OrderId).HasDatabaseName("idx_heo_orden");

    }
}
