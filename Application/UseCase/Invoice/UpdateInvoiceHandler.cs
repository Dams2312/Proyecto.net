using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Invoice;
using Domain.ValueObject.Invoice;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed class UpdateInvoiceHandler
    : IRequestHandler<UpdateInvoice, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateInvoiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateInvoice request,
        CancellationToken ct)
    {
        var entity = await _uow.Invoices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Invoice no encontrado.");

        entity.UpdateOrderId(request.OrderId);
        entity.UpdateStatusId(request.StatusId);
        entity.UpdateUserId(request.UserId);
        entity.UpdateCostoRepuestos(InvoiceCostoRepuestos.Create(request.CostoRepuestos));
        entity.UpdateManoDeObra(InvoiceManoDeObra.Create(request.ManoDeObra));
        entity.UpdateImpuestoPct(InvoiceImpuestoPct.Create(request.ImpuestoPct));
        entity.UpdateDescuento(InvoiceDescuento.Create(request.Descuento));
        entity.UpdateTotal(InvoiceTotal.Create(request.Total));

        await _uow.Invoices.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
