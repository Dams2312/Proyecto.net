using Domain.common;
using Domain.ValueObject.Payment;

namespace Domain.Entities.Payment;

public sealed class Payment : BaseEntity<Guid>
{
    public Guid InvoiceId { get; private set; }

    public Guid PaymentMethodId { get; private set; }

    public PaymentFechaPago FechaPago { get; private set; }

    public PaymentMonto Monto { get; private set; }

    public PaymentReferencia Referencia { get; private set; }

    public PaymentEstado Estado { get; private set; }

    private Payment() { }

    public Payment(
        Guid invoiceId,
        Guid paymentMethodId,
        PaymentFechaPago fechaPago,
        PaymentMonto monto,
        PaymentReferencia referencia,
        PaymentEstado estado)
    {
        InvoiceId = invoiceId;
        PaymentMethodId = paymentMethodId;
        FechaPago = fechaPago;
        Monto = monto;
        Referencia = referencia;
        Estado = estado;
    }
}