using MediatR;

namespace Application.UseCases.Purchase;

public sealed record CreatePurchase(
    DateOnly Date,
    Guid SupplierId,
    Guid UserId,
    string Status,
    string Observations,
    decimal Total
) : IRequest<Guid>;
