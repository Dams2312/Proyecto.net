using System;
using Domain.common;
using Domain.ValueObject.Invoice;

namespace Domain.Entities.Invoice;

public sealed class Invoice : BaseEntity<Guid>
{
    public InvoiceOrderId OrderId { get; private set; }
    public InvoiceStatusId StatusId { get; private set; }
    public InvoiceUserId UserId { get; private set; }
    public InvoiceCostoRepuestos CostoRepuestos { get; private set; }
    public InvoiceManoDeObra ManoDeObra { get; private set; }
    public InvoiceImpuestoPct ImpuestoPct { get; private set; }
    public InvoiceDescuento Descuento { get; private set; }
    public InvoiceTotal Total { get; private set; }

    private Invoice() { }

    public Invoice(
        InvoiceOrderId orderId,
        InvoiceStatusId statusId,
        InvoiceUserId userId,
        InvoiceCostoRepuestos costoRepuestos,
        InvoiceManoDeObra manoDeObra,
        InvoiceImpuestoPct impuestoPct,
        InvoiceDescuento descuento,
        InvoiceTotal total)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        CostoRepuestos = costoRepuestos ?? throw new ArgumentNullException(nameof(costoRepuestos));
        ManoDeObra = manoDeObra ?? throw new ArgumentNullException(nameof(manoDeObra));
        ImpuestoPct = impuestoPct ?? throw new ArgumentNullException(nameof(impuestoPct));
        Descuento = descuento ?? throw new ArgumentNullException(nameof(descuento));
        Total = total ?? throw new ArgumentNullException(nameof(total));
    }

    public void UpdateOrderId(InvoiceOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateStatusId(InvoiceStatusId statusId)
    {
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
    }

    public void UpdateUserId(InvoiceUserId userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public void UpdateCostoRepuestos(InvoiceCostoRepuestos costoRepuestos)
    {
        CostoRepuestos = costoRepuestos ?? throw new ArgumentNullException(nameof(costoRepuestos));
    }

    public void UpdateManoDeObra(InvoiceManoDeObra manoDeObra)
    {
        ManoDeObra = manoDeObra ?? throw new ArgumentNullException(nameof(manoDeObra));
    }

    public void UpdateImpuestoPct(InvoiceImpuestoPct impuestoPct)
    {
        ImpuestoPct = impuestoPct ?? throw new ArgumentNullException(nameof(impuestoPct));
    }

    public void UpdateDescuento(InvoiceDescuento descuento)
    {
        Descuento = descuento ?? throw new ArgumentNullException(nameof(descuento));
    }

    public void UpdateTotal(InvoiceTotal total)
    {
        Total = total ?? throw new ArgumentNullException(nameof(total));
    }
}
