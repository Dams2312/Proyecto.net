using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed class GetOrderMechanicsPagedHandler
    : IRequestHandler<GetOrderMechanicsPaged, IReadOnlyList<OrderMechanicEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderMechanicsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderMechanicEntity>> Handle(
        GetOrderMechanicsPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderMechanics.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

