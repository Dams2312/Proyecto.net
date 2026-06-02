using System.Collections.Generic;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed record GetOrderServiceTypesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderServiceTypeEntity>>;

