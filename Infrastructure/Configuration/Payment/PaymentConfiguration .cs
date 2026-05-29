using Domain.Entities.Payment;
using Domain.ValueObject.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Payments;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InvoiceId)
            .HasConversion(
                x => x.Value,
                x => PaymentInvoiceId.Create(x))
            .HasColumnName("invoice_id")
            .IsRequired();

        builder.Property(x => x.PaymentMethodId)
            .HasConversion(
                x => x.Value,
                x => PaymentMethodId.Create(x))
            .HasColumnName("payment_method_id")
            .IsRequired();

        builder.Property(x => x.FechaPago)
            .HasConversion(
                x => x.Value,
                x => PaymentFechaPago.Create(x))
            .HasColumnName("fecha_pago")
            .IsRequired();

        builder.Property(x => x.Monto)
            .HasConversion(
                x => x.Value,
                x => PaymentMonto.Create(x))
            .HasColumnName("monto")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Referencia)
            .HasConversion(
                x => x.Value,
                x => PaymentReferencia.Create(x))
            .HasColumnName("referencia")
            .HasMaxLength(100);

        builder.Property(x => x.Estado)
            .HasConversion(
                x => x.Value,
                x => PaymentEstado.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();
    }
}