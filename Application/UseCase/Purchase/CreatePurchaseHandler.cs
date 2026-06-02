using Domain.ValueObject.Purchase;
using Application.Abstractions;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed class CreatePurchaseHandler
    : IRequestHandler<CreatePurchase, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreatePurchaseHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreatePurchase request,
        CancellationToken ct)
    {
        var date = PurchaseDate.Create(request.Date);

        var supplierId = PurchaseSupplierId.Create(request.SupplierId);

        var userId = PurchaseUserId.Create(request.UserId);

        var status = PurchaseStatus.Create(request.Status);

        var observations = PurchaseObservations.Create(request.Observations);

        var total = PurchaseTotal.Create(request.Total);

        var purchase = new PurchaseEntity(
            date,
            supplierId,
            userId,
            status,
            observations,
            total);

        await _uow.Purchases.AddAsync(purchase, ct);

        await _uow.SaveChangesAsync(ct);

        return purchase.Id;
    }
}
