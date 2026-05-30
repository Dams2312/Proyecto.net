using System;

namespace Api.Dtos.Appointment;

public sealed class CreateAppointmentRequest
{
    public Guid VehicleId { get; init; }
    public Guid ServiceTypeId { get; init; }
    public Guid ReceptionistId { get; init; }
    public DateTime Date { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public string Status { get; init; } = default!;
    public string Observations { get; init; } = default!;
}
