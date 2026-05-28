using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderStatusHistory;

namespace Domain.Entities.OrderStatusHistory;

public sealed class OrderStatusHistory : BaseEntity<Guid>
{
    public OrderStatusHistoryOrderId OrderId { get; private set; }
    public OrderStatusHistoryStatusId StatusId { get; private set; }
    public OrderStatusHistoryUserId UserId { get; private set; }
    public OrderStatusHistoryFechaCambio FechaCambio { get; private set; }

    private OrderStatusHistory() { }

    public OrderStatusHistory(
        OrderStatusHistoryOrderId orderId,
        OrderStatusHistoryStatusId statusId,
        OrderStatusHistoryUserId userId,
        OrderStatusHistoryFechaCambio fechaCambio)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        FechaCambio = fechaCambio ?? throw new ArgumentNullException(nameof(fechaCambio));
    }

    public void UpdateOrderId(OrderStatusHistoryOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateStatusId(OrderStatusHistoryStatusId statusId)
    {
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
    }

    public void UpdateUserId(OrderStatusHistoryUserId userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public void UpdateFechaCambio(OrderStatusHistoryFechaCambio fechaCambio)
    {
        FechaCambio = fechaCambio ?? throw new ArgumentNullException(nameof(fechaCambio));
    }
}
