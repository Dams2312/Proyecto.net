using System;
using Domain.Entities.OrderService;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed record GetOrderServiceById(
    Guid Id
) : IRequest<OrderService>;
