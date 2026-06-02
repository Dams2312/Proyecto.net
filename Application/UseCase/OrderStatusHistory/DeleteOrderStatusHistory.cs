using System;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed record DeleteOrderStatusHistory(
    Guid Id
) : IRequest<Unit>;

