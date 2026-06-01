using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderService;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed class GetOrderServicesPagedHandler
    : IRequestHandler<GetOrderServicesPaged, IReadOnlyList<OrderService>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServicesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderService>> Handle(
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
