using System.Collections.Generic;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed record GetOrderStatusHistoriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderStatusHistoryEntity>>;

