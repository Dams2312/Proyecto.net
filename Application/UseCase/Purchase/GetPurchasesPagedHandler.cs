using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Purchase;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed class GetPurchasesPagedHandler
    : IRequestHandler<GetPurchasesPaged, IReadOnlyList<Purchase>>
{
    private readonly IUnitOfWork _uow;

    public GetPurchasesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Purchase>> Handle(
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
