using Domain.common;
using Domain.ValueObject.Payment;

namespace Domain.Entities.Payment;

public sealed class Payment : BaseEntity<Guid>
{
    public Guid InvoiceId { get; private set; }

    public Guid PaymentMethodId { get; private set; }

    public PaymentFechaPago FechaPago { get; private set; }

    public PaymentMonto Monto { get; private set; }

    public PaymentReferencia? Referencia { get; private set; }

    public PaymentEstado Estado { get; private set; }

    private Payment() { }

    public Payment(
        Guid invoiceId,
        Guid paymentMethodId,
        PaymentFechaPago fechaPago,
        PaymentMonto monto,
        PaymentReferencia? referencia,
        PaymentEstado estado)
    {
        InvoiceId = invoiceId;
        PaymentMethodId = paymentMethodId;
        FechaPago = fechaPago;
        Monto = monto;
        Referencia = referencia;
        Estado = estado;
    }

    public void UpdateInvoiceId(Guid invoiceId)
    {
        if (invoiceId == Guid.Empty)
            throw new ArgumentException("La factura es obligatoria.", nameof(invoiceId));

        InvoiceId = invoiceId;
    }

    public void UpdatePaymentMethodId(Guid paymentMethodId)
    {
        if (paymentMethodId == Guid.Empty)
            throw new ArgumentException("El método de pago es obligatorio.", nameof(paymentMethodId));

        PaymentMethodId = paymentMethodId;
    }

    public void UpdateFechaPago(PaymentFechaPago fechaPago)
    {
        FechaPago = fechaPago ?? throw new ArgumentNullException(nameof(fechaPago));
    }

    public void UpdateMonto(PaymentMonto monto)
    {
        Monto = monto ?? throw new ArgumentNullException(nameof(monto));
    }

    public void UpdateReferencia(PaymentReferencia? referencia)
    {
        Referencia = referencia;
    }

    public void UpdateEstado(PaymentEstado estado)
    {
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
    }

}
