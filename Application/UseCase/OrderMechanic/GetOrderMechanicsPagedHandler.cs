using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderMechanic;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed class GetOrderMechanicsPagedHandler
    : IRequestHandler<GetOrderMechanicsPaged, IReadOnlyList<OrderMechanic>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderMechanicsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderMechanic>> Handle(
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
