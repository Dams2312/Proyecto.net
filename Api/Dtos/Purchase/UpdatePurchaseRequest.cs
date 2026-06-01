using System;

namespace Api.Dtos.Purchase;

public sealed class UpdatePurchaseRequest
{
    public DateTime Date { get; init; }
    public Guid SupplierId { get; init; }
    public Guid UserId { get; init; }
    public string Status { get; init; } = default!;
    public string Observations { get; init; } = default!;
    public decimal Total { get; init; }
}
