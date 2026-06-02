using System.Collections.Generic;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed record GetOrderDetailsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderDetailEntity>>;

