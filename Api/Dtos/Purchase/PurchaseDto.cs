using System;

namespace Api.Dtos.Purchase;

public sealed class PurchaseDto
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public Guid SupplierId { get; init; }
    public string SupplierName { get; init; } = default!;
    public Guid UserId { get; init; }
    public string UserName { get; init; } = default!;
    public string Status { get; init; } = default!;
    public string Observations { get; init; } = default!;
    public decimal Total { get; init; }
}
