using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.SparePartSupplier;

namespace Domain.Entities.SparePartSupplier;

public sealed class SparePartSupplier : BaseEntity<Guid>
{
    public SparePartSupplierSparePartId SparePartId { get; private set; }
    public SparePartSupplierSupplierId SupplierId { get; private set; }
    public SparePartSupplierPurchasePrice PurchasePrice { get; private set; }
    public SparePartSupplierPrincipal Principal { get; private set; }

    private SparePartSupplier() { }

    public SparePartSupplier(
        SparePartSupplierSparePartId sparePartId,
        SparePartSupplierSupplierId supplierId,
        SparePartSupplierPurchasePrice purchasePrice,
        SparePartSupplierPrincipal principal)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
        SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
        PurchasePrice = purchasePrice ?? throw new ArgumentNullException(nameof(purchasePrice));
        Principal = principal ?? throw new ArgumentNullException(nameof(principal));
    }

    public void UpdateSparePartId(SparePartSupplierSparePartId sparePartId)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
    }

    public void UpdateSupplierId(SparePartSupplierSupplierId supplierId)
    {
        SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    }

    public void UpdatePurchasePrice(SparePartSupplierPurchasePrice purchasePrice)
    {
        PurchasePrice = purchasePrice ?? throw new ArgumentNullException(nameof(purchasePrice));
    }

    public void UpdatePrincipal(SparePartSupplierPrincipal principal)
    {
        Principal = principal ?? throw new ArgumentNullException(nameof(principal));
    }
}
