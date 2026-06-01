using System;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record UpdateOrderDetail(
    Guid Id,
    Guid OrderId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Unit>;
