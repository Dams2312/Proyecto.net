using System.Collections.Generic;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed record GetOrderMechanicsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderMechanicEntity>>;

