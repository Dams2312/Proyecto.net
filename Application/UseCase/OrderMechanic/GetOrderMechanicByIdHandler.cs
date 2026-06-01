using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderMechanic;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed class GetOrderMechanicByIdHandler
    : IRequestHandler<GetOrderMechanicById, OrderMechanic>
{
    private readonly IUnitOfWork _uow;

    public GetOrderMechanicByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderMechanic> Handle(
        GetOrderMechanicById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderMechanics.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderMechanic no encontrado.");

        return entity;
    }
}
