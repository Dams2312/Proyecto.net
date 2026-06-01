using System;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed record DeleteOrderMechanic(
    Guid Id
) : IRequest<Unit>;
