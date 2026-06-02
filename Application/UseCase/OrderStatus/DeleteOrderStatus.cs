using System;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed record DeleteOrderStatus(
    Guid Id
) : IRequest<Unit>;

