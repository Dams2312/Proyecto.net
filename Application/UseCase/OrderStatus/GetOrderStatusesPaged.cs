using System.Collections.Generic;
using Domain.Entities.OrderStatus;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed record GetOrderStatusesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderStatus>>;
