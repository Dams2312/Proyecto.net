using System;

namespace Api.Dtos.OrderMechanic;

public sealed class OrderMechanicDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid MechanicId { get; init; }
    public string MechanicName { get; init; } = default!;
    public DateTime FechaAsignacion { get; init; }
}
