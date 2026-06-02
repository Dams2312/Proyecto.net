using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed record CreatePurchase(
    DateOnly Date,
    Guid SupplierId,
    Guid UserId,
    string Status,
    string Observations,
    decimal Total
) : IRequest<Guid>;

