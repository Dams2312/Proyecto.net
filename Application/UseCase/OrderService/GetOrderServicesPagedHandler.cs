using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class GetOrderServicesPagedHandler
    : IRequestHandler<GetOrderServicesPaged, IReadOnlyList<OrderServiceEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServicesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderServiceEntity>> Handle(
        GetOrderServicesPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderServices.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

