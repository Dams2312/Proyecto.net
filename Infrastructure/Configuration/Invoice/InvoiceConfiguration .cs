using Domain.ValueObject.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Invoice;

public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Domain.Entities.Invoice.Invoice>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Invoice.Invoice> builder)
    {
        builder.ToTable("factura");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // FKs directas como Guid
        builder.Property(x => x.OrderId)
            .HasColumnName("orden_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasColumnName("estado_fact_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(x => x.ManoDeObra)
            .HasConversion(
                x => x.Value,
                x => InvoiceManoDeObra.Create(x))
            .HasColumnName("mano_de_obra")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.CostoRepuestos)
            .HasConversion(
                x => x.Value,
                x => InvoiceCostoRepuestos.Create(x))
            .HasColumnName("costo_repuestos")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.Descuento)
            .HasConversion(
                x => x.Value,
                x => InvoiceDescuento.Create(x))
            .HasColumnName("descuento")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.ImpuestoPct)
            .HasConversion(
                x => x.Value,
                x => InvoiceImpuestoPct.Create(x))
            .HasColumnName("impuesto_pct")
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        // subtotal y total son columnas GENERATED en MySQL → solo lectura
        builder.Property(x => x.Total)
            .HasConversion(
                x => x.Value,
                x => InvoiceTotal.Create(x))
            .HasColumnName("total")
            .HasColumnType("decimal(14,2)")
            .ValueGeneratedOnAddOrUpdate();

        // Relación 1-a-1 con orden_servicio (UNIQUE en SQL)
        builder.HasIndex(x => x.OrderId)
            .IsUnique()
            .HasDatabaseName("uq_factura_orden");

        // FK → orden_servicio
        builder.HasOne<Domain.Entities.OrderService.OrderService>()
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK → estado_factura
        builder.HasOne<Domain.Entities.InvoiceStatus.InvoiceStatus>()
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK → usuario (quien emite)
        builder.HasOne<Domain.Entities.Users.User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}