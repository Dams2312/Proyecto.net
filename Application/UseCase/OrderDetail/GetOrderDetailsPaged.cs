using System.Collections.Generic;
using Domain.Entities.OrderDetail;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record GetOrderDetailsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderDetail>>;
