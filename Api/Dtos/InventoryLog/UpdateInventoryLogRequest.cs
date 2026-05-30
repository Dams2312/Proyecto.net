using System;

namespace Api.Dtos.InventoryLog;

public sealed class UpdateInventoryLogRequest
{
    public Guid SparePartId { get; init; }
    public int Quantity { get; init; }
    public string TypeMovement { get; init; } = default!;
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public Guid OrderId { get; init; }
    public Guid PurchaseId { get; init; }
    public string Reason { get; init; } = default!;
}
