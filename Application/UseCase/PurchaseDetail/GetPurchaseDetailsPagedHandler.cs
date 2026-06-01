using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.PurchaseDetail;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed class GetPurchaseDetailsPagedHandler
    : IRequestHandler<GetPurchaseDetailsPaged, IReadOnlyList<PurchaseDetail>>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseDetailsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PurchaseDetail>> Handle(
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
