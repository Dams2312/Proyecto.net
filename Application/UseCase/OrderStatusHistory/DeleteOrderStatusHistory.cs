using System;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record DeleteOrderStatusHistory(
    Guid Id
) : IRequest<Unit>;
