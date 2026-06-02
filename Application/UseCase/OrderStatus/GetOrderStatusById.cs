using System;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed record GetOrderStatusById(
    Guid Id
) : IRequest<OrderStatusEntity>;

