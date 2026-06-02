using System;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed record UpdateOrderDetail(
    Guid Id,
    Guid OrderId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Unit>;

