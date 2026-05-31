using System;
using Domain.common;
using Domain.ValueObject.Invoice;

namespace Domain.Entities.Invoice;

public sealed class Invoice : BaseEntity<Guid>
{
    // FK COMO GUID
    public Guid OrderId { get; private set; }

    // FK COMO GUID
    public Guid StatusId { get; private set; }

    // FK COMO GUID
    public Guid UserId { get; private set; }

    public InvoiceCostoRepuestos CostoRepuestos { get; private set; }

    public InvoiceManoDeObra ManoDeObra { get; private set; }

    public InvoiceImpuestoPct ImpuestoPct { get; private set; }

    public InvoiceDescuento Descuento { get; private set; }

    public InvoiceTotal Total { get; private set; }

    private Invoice() { }

    public Invoice(
        Guid orderId,
        Guid statusId,
        Guid userId,
        InvoiceCostoRepuestos costoRepuestos,
        InvoiceManoDeObra manoDeObra,
        InvoiceImpuestoPct impuestoPct,
        InvoiceDescuento descuento,
        InvoiceTotal total)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));

        if (statusId == Guid.Empty)
            throw new ArgumentException("El estado es obligatorio.", nameof(statusId));

        if (userId == Guid.Empty)
            throw new ArgumentException("El usuario es obligatorio.", nameof(userId));

        OrderId = orderId;
        StatusId = statusId;
        UserId = userId;

        CostoRepuestos = costoRepuestos ?? throw new ArgumentNullException(nameof(costoRepuestos));

        ManoDeObra = manoDeObra ?? throw new ArgumentNullException(nameof(manoDeObra));

        ImpuestoPct = impuestoPct ?? throw new ArgumentNullException(nameof(impuestoPct));

        Descuento = descuento ?? throw new ArgumentNullException(nameof(descuento));

        Total = total ?? throw new ArgumentNullException(nameof(total));
    }

    public void UpdateOrderId(Guid orderId)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));

        OrderId = orderId;
    }

    public void UpdateStatusId(Guid statusId)
    {
        if (statusId == Guid.Empty)
            throw new ArgumentException("El estado es obligatorio.", nameof(statusId));

        StatusId = statusId;
    }

    public void UpdateUserId(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("El usuario es obligatorio.", nameof(userId));

        UserId = userId;
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