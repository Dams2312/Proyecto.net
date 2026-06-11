using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderStatus;

namespace Domain.Entities.OrderStatus;

public sealed class OrderStatus : BaseEntity<Guid>
{
    public OrderStatusName Name { get; private set; }
    public OrderStatusDescription? Description { get; private set; }

    private OrderStatus() { }

    public OrderStatus(OrderStatusName name, OrderStatusDescription? description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description;
    }

    public void UpdateName(OrderStatusName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateDescription(OrderStatusDescription? description)
    {
        Description = description;
    }
}
