using System;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed record UpdateOrderServiceType(
    Guid Id,
    Guid OrderId,
    Guid ServiceTypeId
) : IRequest<Unit>;

