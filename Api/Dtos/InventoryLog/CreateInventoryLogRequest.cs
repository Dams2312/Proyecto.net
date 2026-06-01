using System;

namespace Api.Dtos.InventoryLog;

public sealed class CreateInventoryLogRequest
{
    public Guid SparePartId { get; init; }
    public int Quantity { get; init; }
    public string TypeMovement { get; init; } = default!; // entrada/salida
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public Guid OrderId { get; init; }
    public Guid PurchaseId { get; init; }
    public string Reason { get; init; } = default!;
}
