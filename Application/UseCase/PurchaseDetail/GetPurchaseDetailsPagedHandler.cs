using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class GetPurchaseDetailsPagedHandler
    : IRequestHandler<GetPurchaseDetailsPaged, IReadOnlyList<PurchaseDetailEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseDetailsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PurchaseDetailEntity>> Handle(
        GetPurchaseDetailsPaged request,
        CancellationToken ct)
    {
        return await _uow.PurchaseDetails.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

