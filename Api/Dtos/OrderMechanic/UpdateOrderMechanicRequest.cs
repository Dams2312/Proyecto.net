using System;

namespace Api.Dtos.OrderMechanic;

public sealed class UpdateOrderMechanicRequest
{
    public Guid OrderId { get; init; }
    public Guid MechanicId { get; init; }
    public DateTime FechaAsignacion { get; init; }
}
