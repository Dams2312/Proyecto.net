using System;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record UpdateOrderServiceType(
    Guid Id,
    Guid OrderId,
    Guid ServiceTypeId
) : IRequest<Unit>;
