using System;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed record DeleteOrderDetail(
    Guid Id
) : IRequest<Unit>;

