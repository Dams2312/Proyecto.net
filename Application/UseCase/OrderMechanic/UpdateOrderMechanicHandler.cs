using Domain.ValueObject.OrderMechanic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed class UpdateOrderMechanicHandler
    : IRequestHandler<UpdateOrderMechanic, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderMechanicHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderMechanic request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderMechanics.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderMechanicEntity no encontrado.");

        entity.UpdateOrderId(OrderMechanicOrderId.Create(request.OrderId));
        entity.UpdateMechanicId(OrderMechanicMechanicId.Create(request.MechanicId));
        entity.UpdateFechaAsignacion(OrderMechanicFechaAsignacion.Create(DateOnly.FromDateTime(request.FechaAsignacion)));

        await _uow.OrderMechanics.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

