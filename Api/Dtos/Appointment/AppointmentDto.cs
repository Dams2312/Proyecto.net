using System;

namespace Api.Dtos.Appointment;

public sealed class AppointmentDto
{
    public Guid Id { get; init; }
    public Guid VehicleId { get; init; }
    public string VehiclePlate { get; init; } = default!;
    public Guid ServiceTypeId { get; init; }
    public string ServiceTypeName { get; init; } = default!;
    public Guid ReceptionistId { get; init; }
    public string ReceptionistName { get; init; } = default!;
    public DateTime Date { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public string Status { get; init; } = default!;
    public string Observations { get; init; } = default!;
}
