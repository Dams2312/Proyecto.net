using System;
using Domain.Entities.OrderMechanic;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record GetOrderMechanicById(
    Guid Id
) : IRequest<OrderMechanic>;
