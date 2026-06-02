using System;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed record UpdateOrderStatus(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;

