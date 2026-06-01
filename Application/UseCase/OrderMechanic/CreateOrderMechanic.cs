using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record CreateOrderMechanic(
    Guid OrderId,
    Guid MechanicId,
    DateOnly FechaAsignacion
) : IRequest<Guid>;
