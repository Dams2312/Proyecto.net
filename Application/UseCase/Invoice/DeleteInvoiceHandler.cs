using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed class DeleteInvoiceHandler
    : IRequestHandler<DeleteInvoice, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteInvoiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteInvoice request,
        CancellationToken ct)
    {
        var entity = await _uow.Invoices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Invoice no encontrado.");

        await _uow.Invoices.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
