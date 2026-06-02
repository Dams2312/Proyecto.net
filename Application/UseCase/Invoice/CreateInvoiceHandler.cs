using Domain.ValueObject.Invoice;
using Application.Abstractions;
using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed class CreateInvoiceHandler
    : IRequestHandler<CreateInvoice, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateInvoiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateInvoice request,
        CancellationToken ct)
    {
        var orderId = request.OrderId;

        var statusId = request.StatusId;

        var userId = request.UserId;

        var costoRepuestos = InvoiceCostoRepuestos.Create(request.CostoRepuestos);

        var manoDeObra = InvoiceManoDeObra.Create(request.ManoDeObra);

        var impuestoPct = InvoiceImpuestoPct.Create(request.ImpuestoPct);

        var descuento = InvoiceDescuento.Create(request.Descuento);

        var total = InvoiceTotal.Create(request.Total);

        var invoice = new InvoiceEntity(
            orderId,
            statusId,
            userId,
            costoRepuestos,
            manoDeObra,
            impuestoPct,
            descuento,
            total);

        await _uow.Invoices.AddAsync(invoice, ct);

        await _uow.SaveChangesAsync(ct);

        return invoice.Id;
    }
}
