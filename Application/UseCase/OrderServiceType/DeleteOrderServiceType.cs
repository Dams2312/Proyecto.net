using System;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed record DeleteOrderServiceType(
    Guid Id
) : IRequest<Unit>;

