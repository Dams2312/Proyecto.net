using System.Collections.Generic;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed record GetPurchaseDetailsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PurchaseDetailEntity>>;

