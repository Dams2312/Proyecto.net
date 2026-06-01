using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InvoiceStatus;
using Domain.ValueObject.InvoiceStatus;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed class UpdateInvoiceStatusHandler
    : IRequestHandler<UpdateInvoiceStatus, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateInvoiceStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateInvoiceStatus request,
        CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InvoiceStatus no encontrado.");

        entity.UpdateName(InvoiceStatusName.Create(request.Name));

        await _uow.InvoiceStatuses.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
