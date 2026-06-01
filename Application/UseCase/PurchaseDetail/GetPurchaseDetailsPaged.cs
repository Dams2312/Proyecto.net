using System.Collections.Generic;
using Domain.Entities.PurchaseDetail;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record GetPurchaseDetailsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PurchaseDetail>>;
