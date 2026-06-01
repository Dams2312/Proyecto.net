using System;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record UpdateOrderStatusHistory(
    Guid Id,
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    DateTime FechaCambio
) : IRequest<Unit>;
