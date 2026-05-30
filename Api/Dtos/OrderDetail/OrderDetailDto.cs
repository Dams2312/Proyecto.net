using System;

namespace Api.Dtos.OrderDetail;

public sealed class OrderDetailDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid SparePartId { get; init; }
    public string SparePartCode { get; init; } = default!;
    public int Quantity { get; init; }
    public decimal PriceSnapshot { get; init; }
    public decimal Subtotal { get; init; }
}
