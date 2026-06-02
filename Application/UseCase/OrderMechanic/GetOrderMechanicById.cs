using System;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed record GetOrderMechanicById(
    Guid Id
) : IRequest<OrderMechanicEntity>;

