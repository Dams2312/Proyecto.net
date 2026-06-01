using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record CreateOrderDetail(
    Guid OrderId,
    Guid SparePartId,
    int Quantity,
    decimal PriceSnapshot
) : IRequest<Guid>;