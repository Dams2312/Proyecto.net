using System.Collections.Generic;
using Domain.Entities.OrderStatusHistory;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record GetOrderStatusHistoriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderStatusHistory>>;
