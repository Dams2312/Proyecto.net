using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderServiceType;

namespace Domain.Entities.OrderServiceType;

public sealed class OrderServiceType : BaseEntity<Guid>
{
    public OrderServiceTypeOrderId OrderId { get; private set; }
    public OrderServiceTypeServiceTypeId ServiceTypeId { get; private set; }

    private OrderServiceType() { }

    public OrderServiceType(OrderServiceTypeOrderId orderId, OrderServiceTypeServiceTypeId serviceTypeId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
    }

    public void UpdateOrderId(OrderServiceTypeOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateServiceTypeId(OrderServiceTypeServiceTypeId serviceTypeId)
    {
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
    }
}
