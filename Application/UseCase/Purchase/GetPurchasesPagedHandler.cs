using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed class GetPurchasesPagedHandler
    : IRequestHandler<GetPurchasesPaged, IReadOnlyList<PurchaseEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetPurchasesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PurchaseEntity>> Handle(
        GetPurchasesPaged request,
        CancellationToken ct)
    {
        return await _uow.Purchases.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
