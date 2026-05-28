using System;
using Domain.common;
using Domain.ValueObject.OrderDetail;

namespace Domain.Entities.OrderDetail;

public sealed class OrderDetail : BaseEntity<Guid>
{
    public OrderDetailOrderId OrderId { get; private set; }
    public OrderDetailSparePartId SparePartId { get; private set; }
    public OrderDetailQuantity Quantity { get; private set; }
    public OrderDetailPriceSnapshot PriceSnapshot { get; private set; }

    private OrderDetail() { }

    public OrderDetail(
        OrderDetailOrderId orderId,
        OrderDetailSparePartId sparePartId,
        OrderDetailQuantity quantity,
        OrderDetailPriceSnapshot priceSnapshot)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
        PriceSnapshot = priceSnapshot ?? throw new ArgumentNullException(nameof(priceSnapshot));
    }

    public void UpdateOrderId(OrderDetailOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateSparePartId(OrderDetailSparePartId sparePartId)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
    }

    public void UpdateQuantity(OrderDetailQuantity quantity)
    {
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
    }

    public void UpdatePriceSnapshot(OrderDetailPriceSnapshot priceSnapshot)
    {
        PriceSnapshot = priceSnapshot ?? throw new ArgumentNullException(nameof(priceSnapshot));
    }
}
