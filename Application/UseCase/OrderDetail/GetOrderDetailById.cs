using System;
using Domain.Entities.OrderDetail;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record GetOrderDetailById(
    Guid Id
) : IRequest<OrderDetail>;
