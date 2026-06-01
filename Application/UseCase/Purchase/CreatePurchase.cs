using MediatR;

namespace Application.UseCases.Purchase;

public sealed record CreatePurchase(
    DateOnly Date,
    int SupplierId,
    int UserId,
    string Status,
    string Observations,
    decimal Total
) : IRequest<Guid>;
