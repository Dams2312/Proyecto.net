using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed class DeleteInvoiceStatusHandler
    : IRequestHandler<DeleteInvoiceStatus, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteInvoiceStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteInvoiceStatus request,
        CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InvoiceStatus no encontrado.");

        await _uow.InvoiceStatuses.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
