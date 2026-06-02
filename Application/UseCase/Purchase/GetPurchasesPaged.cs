using System.Collections.Generic;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed record GetPurchasesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PurchaseEntity>>;
