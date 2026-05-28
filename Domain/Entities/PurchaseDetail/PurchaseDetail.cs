using System;
using Domain.common;
using Domain.ValueObject.PurchaseDetail;

namespace Domain.Entities.PurchaseDetail;

public sealed class PurchaseDetail : BaseEntity<Guid>
{
    public PurchaseDetailPurchaseId PurchaseId { get; private set; }
    public PurchaseDetailSparePartId SparePartId { get; private set; }
    public PurchaseDetailQuantity Quantity { get; private set; }
    public PurchaseDetailUnitPrice UnitPrice { get; private set; }

    private PurchaseDetail() { }

    public PurchaseDetail(
        PurchaseDetailPurchaseId purchaseId,
        PurchaseDetailSparePartId sparePartId,
        PurchaseDetailQuantity quantity,
        PurchaseDetailUnitPrice unitPrice)
    {
        PurchaseId = purchaseId ?? throw new ArgumentNullException(nameof(purchaseId));
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }

    public void UpdatePurchaseId(PurchaseDetailPurchaseId purchaseId)
    {
        PurchaseId = purchaseId ?? throw new ArgumentNullException(nameof(purchaseId));
    }

    public void UpdateSparePartId(PurchaseDetailSparePartId sparePartId)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
    }

    public void UpdateQuantity(PurchaseDetailQuantity quantity)
    {
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
    }

    public void UpdateUnitPrice(PurchaseDetailUnitPrice unitPrice)
    {
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }
}
