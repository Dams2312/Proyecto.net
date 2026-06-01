using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderStatusHistory;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed class GetOrderStatusHistoriesPagedHandler
    : IRequestHandler<GetOrderStatusHistoriesPaged, IReadOnlyList<OrderStatusHistory>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusHistoriesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderStatusHistory>> Handle(
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
