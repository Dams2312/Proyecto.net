using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed class GetOrderStatusesPagedHandler
    : IRequestHandler<GetOrderStatusesPaged, IReadOnlyList<OrderStatusEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderStatusEntity>> Handle(
        GetOrderStatusesPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderStatuses.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

