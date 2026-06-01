using System;
using Domain.Entities.OrderServiceType;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record GetOrderServiceTypeById(
    Guid Id
) : IRequest<OrderServiceType>;
