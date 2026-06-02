using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed record CreatePurchaseDetail(
    Guid PurchaseId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Guid>;
