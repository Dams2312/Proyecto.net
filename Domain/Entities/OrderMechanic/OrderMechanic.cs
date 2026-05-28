using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderMechanic;

namespace Domain.Entities.OrderMechanic;

public sealed class OrderMechanic : BaseEntity<Guid>
{
    public OrderMechanicOrderId OrderId { get; private set; }
    public OrderMechanicMechanicId MechanicId { get; private set; }
    public OrderMechanicFechaAsignacion FechaAsignacion { get; private set; }

    private OrderMechanic() { }

    public OrderMechanic(OrderMechanicOrderId orderId, OrderMechanicMechanicId mechanicId, OrderMechanicFechaAsignacion fechaAsignacion)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        MechanicId = mechanicId ?? throw new ArgumentNullException(nameof(mechanicId));
        FechaAsignacion = fechaAsignacion ?? throw new ArgumentNullException(nameof(fechaAsignacion));
    }

    public void UpdateOrderId(OrderMechanicOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateMechanicId(OrderMechanicMechanicId mechanicId)
    {
        MechanicId = mechanicId ?? throw new ArgumentNullException(nameof(mechanicId));
    }

    public void UpdateFechaAsignacion(OrderMechanicFechaAsignacion fechaAsignacion)
    {
        FechaAsignacion = fechaAsignacion ?? throw new ArgumentNullException(nameof(fechaAsignacion));
    }
}
