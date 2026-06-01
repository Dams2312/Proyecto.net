using System;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed record UpdateOrderStatus(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;
