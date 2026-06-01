using System;
using Domain.Entities.OrderStatusHistory;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record GetOrderStatusHistoryById(
    Guid Id
) : IRequest<OrderStatusHistory>;
