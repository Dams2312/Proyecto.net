using System;

namespace Api.Dtos.SparePartSupplier;

public sealed class SparePartSupplierDto
{
    public Guid Id { get; init; }
    public Guid SparePartId { get; init; }
    public string SparePartCode { get; init; } = default!;
    public Guid SupplierId { get; init; }
    public string SupplierName { get; init; } = default!;
    public decimal PurchasePrice { get; init; }
    public bool Principal { get; init; }
}
