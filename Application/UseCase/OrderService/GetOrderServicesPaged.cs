using System.Collections.Generic;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed record GetOrderServicesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderServiceEntity>>;

