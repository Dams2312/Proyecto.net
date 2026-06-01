using System;
using Domain.Entities.OrderStatus;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed record GetOrderStatusById(
    Guid Id
) : IRequest<OrderStatus>;
