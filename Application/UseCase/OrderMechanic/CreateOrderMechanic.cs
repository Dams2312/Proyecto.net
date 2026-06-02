using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed record CreateOrderMechanic(
    Guid OrderId,
    Guid MechanicId,
    DateOnly FechaAsignacion
) : IRequest<Guid>;

