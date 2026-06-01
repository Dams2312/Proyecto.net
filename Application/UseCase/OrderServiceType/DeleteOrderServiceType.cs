using System;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record DeleteOrderServiceType(
    Guid Id
) : IRequest<Unit>;
