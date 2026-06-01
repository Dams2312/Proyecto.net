using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderStatus;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed class GetOrderStatusesPagedHandler
    : IRequestHandler<GetOrderStatusesPaged, IReadOnlyList<OrderStatus>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderStatus>> Handle(
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
