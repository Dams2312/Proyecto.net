using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed class GetOrderServiceTypesPagedHandler
    : IRequestHandler<GetOrderServiceTypesPaged, IReadOnlyList<OrderServiceTypeEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceTypesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderServiceTypeEntity>> Handle(
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

