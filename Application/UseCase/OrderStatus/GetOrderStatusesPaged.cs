using System.Collections.Generic;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed record GetOrderStatusesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderStatusEntity>>;

