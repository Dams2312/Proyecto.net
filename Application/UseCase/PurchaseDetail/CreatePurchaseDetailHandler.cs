using Domain.ValueObject.PurchaseDetail;
using Application.Abstractions;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class CreatePurchaseDetailHandler
    : IRequestHandler<CreatePurchaseDetail, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreatePurchaseDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreatePurchaseDetail request,
        CancellationToken ct)
    {
        var purchaseId = PurchaseDetailPurchaseId.Create(request.PurchaseId);
        var sparePartId = PurchaseDetailSparePartId.Create(request.SparePartId);
        var quantity = PurchaseDetailQuantity.Create(request.Quantity);
        var unitPrice = PurchaseDetailUnitPrice.Create(request.UnitPrice);

        var purchaseDetail = new PurchaseDetailEntity(purchaseId, sparePartId, quantity, unitPrice);

        await _uow.PurchaseDetails.AddAsync(purchaseDetail, ct);
        await _uow.SaveChangesAsync(ct);

        return purchaseDetail.Id;
    }
}
