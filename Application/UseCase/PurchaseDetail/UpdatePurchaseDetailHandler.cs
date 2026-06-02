using Domain.ValueObject.PurchaseDetail;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class UpdatePurchaseDetailHandler
    : IRequestHandler<UpdatePurchaseDetail, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdatePurchaseDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdatePurchaseDetail request,
        CancellationToken ct)
    {
        var entity = await _uow.PurchaseDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseDetailEntity no encontrado.");

        entity.UpdatePurchaseId(PurchaseDetailPurchaseId.Create(request.PurchaseId));
        entity.UpdateSparePartId(PurchaseDetailSparePartId.Create(request.SparePartId));
        entity.UpdateQuantity(PurchaseDetailQuantity.Create(request.Quantity));
        entity.UpdateUnitPrice(PurchaseDetailUnitPrice.Create(request.UnitPrice));

        await _uow.PurchaseDetails.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

