using System;
using Domain.common;
using Domain.ValueObject.Payment;

namespace Domain.Entities.Payment;

public sealed class Payment : BaseEntity<Guid>
{
    public PaymentInvoiceId InvoiceId { get; private set; }
    public PaymentMethodId PaymentMethodId { get; private set; }
    public PaymentFechaPago FechaPago { get; private set; }
    public PaymentMonto Monto { get; private set; }
    public PaymentReferencia Referencia { get; private set; }
    public PaymentEstado Estado { get; private set; }

    private Payment() { }

    public Payment(
        PaymentInvoiceId invoiceId,
        PaymentMethodId paymentMethodId,
        PaymentFechaPago fechaPago,
        PaymentMonto monto,
        PaymentReferencia referencia,
        PaymentEstado estado)
    {
        InvoiceId = invoiceId ?? throw new ArgumentNullException(nameof(invoiceId));
        PaymentMethodId = paymentMethodId ?? throw new ArgumentNullException(nameof(paymentMethodId));
        FechaPago = fechaPago ?? throw new ArgumentNullException(nameof(fechaPago));
        Monto = monto ?? throw new ArgumentNullException(nameof(monto));
        Referencia = referencia ?? throw new ArgumentNullException(nameof(referencia));
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
    }

    public void UpdateInvoiceId(PaymentInvoiceId invoiceId)
    {
        InvoiceId = invoiceId ?? throw new ArgumentNullException(nameof(invoiceId));
    }

    public void UpdatePaymentMethodId(PaymentMethodId paymentMethodId)
    {
        PaymentMethodId = paymentMethodId ?? throw new ArgumentNullException(nameof(paymentMethodId));
    }

    public void UpdateFechaPago(PaymentFechaPago fechaPago)
    {
        FechaPago = fechaPago ?? throw new ArgumentNullException(nameof(fechaPago));
    }

    public void UpdateMonto(PaymentMonto monto)
    {
        Monto = monto ?? throw new ArgumentNullException(nameof(monto));
    }

    public void UpdateReferencia(PaymentReferencia referencia)
    {
        Referencia = referencia ?? throw new ArgumentNullException(nameof(referencia));
    }

    public void UpdateEstado(PaymentEstado estado)
    {
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
    }
}
