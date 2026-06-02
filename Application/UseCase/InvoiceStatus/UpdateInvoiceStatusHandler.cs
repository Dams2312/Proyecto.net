using Domain.ValueObject.InvoiceStatus;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

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
            throw new KeyNotFoundException("InvoiceStatusEntity no encontrado.");

        entity.UpdateName(InvoiceStatusName.Create(request.Name));

        await _uow.InvoiceStatuses.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

