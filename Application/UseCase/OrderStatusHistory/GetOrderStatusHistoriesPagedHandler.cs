using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class GetOrderStatusHistoriesPagedHandler
    : IRequestHandler<GetOrderStatusHistoriesPaged, IReadOnlyList<OrderStatusHistoryEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusHistoriesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderStatusHistoryEntity>> Handle(
        GetOrderStatusHistoriesPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderStatusHistories.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

