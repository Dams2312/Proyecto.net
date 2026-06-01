using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Purchase;
using Domain.ValueObject.Purchase;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed class UpdatePurchaseHandler
    : IRequestHandler<UpdatePurchase, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdatePurchaseHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdatePurchase request,
        CancellationToken ct)
    {
        var entity = await _uow.Purchases.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Purchase no encontrado.");

        entity.UpdateDate(PurchaseDate.Create(request.Date));
        entity.UpdateSupplierId(PurchaseSupplierId.Create(request.SupplierId));
        entity.UpdateUserId(PurchaseUserId.Create(request.UserId));
        entity.UpdateStatus(PurchaseStatus.Create(request.Status));
        entity.UpdateObservations(PurchaseObservations.Create(request.Observations));
        entity.UpdateTotal(PurchaseTotal.Create(request.Total));

        await _uow.Purchases.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
