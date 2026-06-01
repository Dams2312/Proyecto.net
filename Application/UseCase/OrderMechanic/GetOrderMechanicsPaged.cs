using System.Collections.Generic;
using Domain.Entities.OrderMechanic;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record GetOrderMechanicsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderMechanic>>;
