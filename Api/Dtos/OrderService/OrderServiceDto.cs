using System;

namespace Api.Dtos.OrderService;

public sealed class OrderServiceDto
{
    public Guid Id { get; init; }
    public Guid VehicleId { get; init; }
    public string VehiclePlate { get; init; } = default!;
    public Guid ReceptionistId { get; init; }
    public string ReceptionistName { get; init; } = default!;
    public Guid StatusId { get; init; }
    public string StatusName { get; init; } = default!;
    public int KilometrajeIngreso { get; init; }
    public DateTime FechaIngreso { get; init; }
    public DateTime? FechaEstimada { get; init; }
    public DateTime? FechaEntregaReal { get; init; }
    public Guid? AppointmentId { get; init; }
    public string Observaciones { get; init; } = default!;
}
