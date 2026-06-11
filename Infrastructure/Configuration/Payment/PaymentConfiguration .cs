using Domain.ValueObject.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Payment;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Domain.Entities.Payment.Payment>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Payment.Payment> builder)
    {
        builder.ToTable("pago");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.InvoiceId)
            .HasColumnName("factura_id")
            .IsRequired();

        builder.Property(x => x.PaymentMethodId)
            .HasColumnName("metodo_pago_id")
            .IsRequired();

        builder.Property(x => x.Monto)
            .HasConversion(
                x => x.Value,
                x => PaymentMonto.Create(x))
            .HasColumnName("monto")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(x => x.FechaPago)
            .HasConversion(
                x => x.Value,
                x => PaymentFechaPago.Create(x))
            .HasColumnName("fecha_pago")
            .IsRequired();

        builder.Property(x => x.Referencia)
            .HasConversion(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<PaymentReferencia?, string?>(
                x => x == null ? (string?)null : x.Value,
                x => x == null ? null : PaymentReferencia.Create(x)))
            .HasColumnName("referencia")
            .HasMaxLength(100);

        builder.Property(x => x.Estado)
            .HasConversion(
                x => x.Value,
                x => PaymentEstado.Create(x))
            .HasColumnName("estado")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.InvoiceId)
            .HasDatabaseName("idx_pago_factura");

        builder.HasOne<Domain.Entities.Invoice.Invoice>()
            .WithMany()
            .HasForeignKey(x => x.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.PaymentMethod.PaymentMethod>()
            .WithMany()
            .HasForeignKey(x => x.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
