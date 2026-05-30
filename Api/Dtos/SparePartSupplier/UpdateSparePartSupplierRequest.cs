using System;

namespace Api.Dtos.SparePartSupplier;

public sealed class UpdateSparePartSupplierRequest
{
    public Guid SparePartId { get; init; }
    public Guid SupplierId { get; init; }
    public decimal PurchasePrice { get; init; }
    public bool Principal { get; init; }
}
