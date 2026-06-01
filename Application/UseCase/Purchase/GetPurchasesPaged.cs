using System.Collections.Generic;
using Domain.Entities.Purchase;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed record GetPurchasesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Purchase>>;
