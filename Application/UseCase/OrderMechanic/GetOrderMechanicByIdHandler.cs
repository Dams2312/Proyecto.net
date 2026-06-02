using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed class GetOrderMechanicByIdHandler
    : IRequestHandler<GetOrderMechanicById, OrderMechanicEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderMechanicByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderMechanicEntity> Handle(
        GetOrderMechanicById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderMechanics.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderMechanicEntity no encontrado.");

        return entity;
    }
}

