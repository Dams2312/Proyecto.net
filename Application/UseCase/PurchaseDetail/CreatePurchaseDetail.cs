using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record CreatePurchaseDetail(
    Guid PurchaseId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Guid>;