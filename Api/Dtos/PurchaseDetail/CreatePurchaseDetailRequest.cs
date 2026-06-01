using System;

namespace Api.Dtos.PurchaseDetail;

public sealed class CreatePurchaseDetailRequest
{
    public Guid PurchaseId { get; init; }
    public Guid SparePartId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}
