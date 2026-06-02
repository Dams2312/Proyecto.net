using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed class GetOrderDetailsPagedHandler
    : IRequestHandler<GetOrderDetailsPaged, IReadOnlyList<OrderDetailEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderDetailsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderDetailEntity>> Handle(
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

