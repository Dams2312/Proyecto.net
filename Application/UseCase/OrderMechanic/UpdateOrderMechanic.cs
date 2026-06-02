using System;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed record UpdateOrderMechanic(
    Guid Id,
    Guid OrderId,
    Guid MechanicId,
    DateTime FechaAsignacion
) : IRequest<Unit>;

