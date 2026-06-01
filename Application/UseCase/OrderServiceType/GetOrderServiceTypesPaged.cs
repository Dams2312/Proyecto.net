using System.Collections.Generic;
using Domain.Entities.OrderServiceType;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record GetOrderServiceTypesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderServiceType>>;
