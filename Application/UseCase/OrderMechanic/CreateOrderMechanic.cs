using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record CreateOrderMechanic(
    int OrderId,
    int MechanicId,
    DateOnly FechaAsignacion
) : IRequest<Guid>;
