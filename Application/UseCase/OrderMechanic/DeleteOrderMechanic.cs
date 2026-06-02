using System;
using MediatR;
using OrderMechanicEntity = Domain.Entities.OrderMechanic.OrderMechanic;

namespace Application.UseCase.OrderMechanic;

public sealed record DeleteOrderMechanic(
    Guid Id
) : IRequest<Unit>;

