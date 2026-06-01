using System;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed record DeleteOrderService(
    Guid Id
) : IRequest<Unit>;
