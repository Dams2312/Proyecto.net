using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record CreateOrderDetail(
    int OrderId,
    int SparePartId,
    int Quantity,
    decimal PriceSnapshot
) : IRequest<Guid>;