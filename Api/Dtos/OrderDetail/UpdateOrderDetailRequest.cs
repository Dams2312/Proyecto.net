using System;

namespace Api.Dtos.OrderDetail;

public sealed class UpdateOrderDetailRequest
{
    public Guid OrderId { get; init; }
    public Guid SparePartId { get; init; }
    public int Quantity { get; init; }
    public decimal PriceSnapshot { get; init; }
}
