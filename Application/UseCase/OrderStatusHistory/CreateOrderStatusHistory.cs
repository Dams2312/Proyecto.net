using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed record CreateOrderStatusHistory(
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    DateTime FechaCambio
) : IRequest<Guid>;
