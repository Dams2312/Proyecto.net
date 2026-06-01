using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record CreateMechanicTask(
    Guid OrderId,
    Guid MechanicId,
    Guid ServiceTypeId,
    string Description,
    decimal HourlyCost,
    decimal HoursWorked,
    DateTime FechaInicio,
    DateTime FechaFin,
    string Status
) : IRequest<Guid>;