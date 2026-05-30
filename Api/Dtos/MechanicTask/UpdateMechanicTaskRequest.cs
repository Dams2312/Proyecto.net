using System;

namespace Api.Dtos.MechanicTask;

public sealed class UpdateMechanicTaskRequest
{
    public Guid OrderId { get; init; }
    public Guid MechanicId { get; init; }
    public Guid ServiceTypeId { get; init; }
    public string Description { get; init; } = default!;
    public string Status { get; init; } = default!;
    public DateTime? FechaInicio { get; init; }
    public DateTime? FechaFin { get; init; }
    public decimal HoursWorked { get; init; }
    public decimal HourlyCost { get; init; }
}
