using System;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed record UpdateOrderStatusHistory(
    Guid Id,
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    DateTime FechaCambio
) : IRequest<Unit>;

