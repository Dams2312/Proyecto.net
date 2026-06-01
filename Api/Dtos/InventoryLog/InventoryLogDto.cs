using System;

namespace Api.Dtos.InventoryLog;

public sealed class InventoryLogDto
{
    public Guid Id { get; init; }
    public Guid SparePartId { get; init; }
    public string SparePartCode { get; init; } = default!;
    public int Quantity { get; init; }
    public int StockResultant { get; init; }
    public string TypeMovement { get; init; } = default!; // entrada/salida
    public Guid UserId { get; init; }
    public string UserName { get; init; } = default!;
    public DateTime Date { get; init; }
    public Guid OrderId { get; init; }
    public Guid PurchaseId { get; init; }
    public string Reason { get; init; } = default!;
}
