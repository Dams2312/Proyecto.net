using System;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed record DeleteOrderStatus(
    Guid Id
) : IRequest<Unit>;
