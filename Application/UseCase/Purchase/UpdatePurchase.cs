using System;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed record UpdatePurchase(
    Guid Id,
    DateTime Date,
    Guid SupplierId,
    Guid UserId,
    string Status,
    string Observations,
    decimal Total
) : IRequest<Unit>;
