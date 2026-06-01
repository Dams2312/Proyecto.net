using System.Collections.Generic;
using Domain.Entities.OrderService;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed record GetOrderServicesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderService>>;
