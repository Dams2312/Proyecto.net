using System;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed record GetOrderServiceTypeById(
    Guid Id
) : IRequest<OrderServiceTypeEntity>;

