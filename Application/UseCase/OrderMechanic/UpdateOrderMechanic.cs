using System;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record UpdateOrderMechanic(
    Guid Id,
    Guid OrderId,
    Guid MechanicId,
    DateTime FechaAsignacion
) : IRequest<Unit>;
