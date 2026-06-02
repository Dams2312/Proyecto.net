using Domain.ValueObject.OrderMechanic;
using Application.Abstractions;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed class CreateOrderMechanicHandler
    : IRequestHandler<CreateOrderMechanic, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderMechanicHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderMechanic request,
        CancellationToken ct)
    {
        var orderId = OrderMechanicOrderId.Create(request.OrderId);

        var mechanicId = OrderMechanicMechanicId.Create(request.MechanicId);

        var fechaAsignacion = OrderMechanicFechaAsignacion.Create(request.FechaAsignacion);

        var orderMechanic = new OrderMechanicEntity(
            orderId,
            mechanicId,
            fechaAsignacion);

        await _uow.OrderMechanics.AddAsync(orderMechanic, ct);

        await _uow.SaveChangesAsync(ct);

        return orderMechanic.Id;
    }
}
