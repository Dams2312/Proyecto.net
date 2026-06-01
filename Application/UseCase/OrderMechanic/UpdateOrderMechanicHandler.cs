using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderMechanic;
using Domain.ValueObject.OrderMechanic;
using MediatR;

namespace Application.UseCases.OrderMechanic;

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
            throw new KeyNotFoundException("OrderMechanic no encontrado.");

        entity.UpdateOrderId(OrderMechanicOrderId.Create(request.OrderId));
        entity.UpdateMechanicId(OrderMechanicMechanicId.Create(request.MechanicId));
        entity.UpdateFechaAsignacion(OrderMechanicFechaAsignacion.Create(request.FechaAsignacion));

        await _uow.OrderMechanics.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
