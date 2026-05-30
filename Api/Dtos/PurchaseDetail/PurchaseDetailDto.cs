using System;

namespace Api.Dtos.PurchaseDetail;

public sealed class PurchaseDetailDto
{
    public Guid Id { get; init; }
    public Guid PurchaseId { get; init; }
    public Guid SparePartId { get; init; }
    public string SparePartCode { get; init; } = default!;
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Subtotal { get; init; }
}
