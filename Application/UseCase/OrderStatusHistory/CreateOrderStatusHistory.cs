using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record CreateOrderStatusHistory(
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    DateTime FechaCambio
) : IRequest<Guid>;