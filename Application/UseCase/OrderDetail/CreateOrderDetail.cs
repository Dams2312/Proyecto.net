using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed record CreateOrderDetail(
    Guid OrderId,
    Guid SparePartId,
    int Quantity,
    decimal PriceSnapshot
) : IRequest<Guid>;
