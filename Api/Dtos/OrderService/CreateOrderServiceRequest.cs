using System;

namespace Api.Dtos.OrderService;

public sealed class CreateOrderServiceRequest
{
    public Guid VehicleId { get; init; }
    public Guid ReceptionistId { get; init; }
    public Guid StatusId { get; init; }
    public int KilometrajeIngreso { get; init; }
    public DateTime FechaIngreso { get; init; }
    public DateTime? FechaEstimada { get; init; }
    public DateTime? FechaEntregaReal { get; init; }
    public Guid? AppointmentId { get; init; }
    public string Observaciones { get; init; } = default!;
}
