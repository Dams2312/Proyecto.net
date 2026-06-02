using System;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed record GetOrderServiceById(
    Guid Id
) : IRequest<OrderServiceEntity>;

