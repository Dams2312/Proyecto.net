using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record CreatePurchaseDetail(
    int PurchaseId,
    int SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Guid>;