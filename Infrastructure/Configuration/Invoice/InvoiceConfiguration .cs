using Domain.Entities.Invoice;
using Domain.ValueObject.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Invoices;

public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasConversion(
                x => x.Value,
                x => InvoiceOrderId.Create(x))
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasConversion(
                x => x.Value,
                x => InvoiceStatusId.Create(x))
            .HasColumnName("status_id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                x => x.Value,
                x => InvoiceUserId.Create(x))
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.CostoRepuestos)
            .HasConversion(
                x => x.Value,
                x => InvoiceCostoRepuestos.Create(x))
            .HasColumnName("costo_repuestos")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ManoDeObra)
            .HasConversion(
                x => x.Value,
                x => InvoiceManoDeObra.Create(x))
            .HasColumnName("mano_de_obra")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ImpuestoPct)
            .HasConversion(
                x => x.Value,
                x => InvoiceImpuestoPct.Create(x))
            .HasColumnName("impuesto_pct")
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(x => x.Descuento)
            .HasConversion(
                x => x.Value,
                x => InvoiceDescuento.Create(x))
            .HasColumnName("descuento")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Total)
            .HasConversion(
                x => x.Value,
                x => InvoiceTotal.Create(x))
            .HasColumnName("total")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}