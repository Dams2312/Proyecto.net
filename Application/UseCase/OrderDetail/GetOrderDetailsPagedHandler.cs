using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderDetail;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed class GetOrderDetailsPagedHandler
    : IRequestHandler<GetOrderDetailsPaged, IReadOnlyList<OrderDetail>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderDetailsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderDetail>> Handle(
        GetOrderDetailsPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderDetails.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
