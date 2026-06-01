using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderServiceType;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed class GetOrderServiceTypesPagedHandler
    : IRequestHandler<GetOrderServiceTypesPaged, IReadOnlyList<OrderServiceType>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceTypesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderServiceType>> Handle(
        GetOrderServiceTypesPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderServiceTypes.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
