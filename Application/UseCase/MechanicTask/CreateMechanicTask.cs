using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record CreateMechanicTask(
    int OrderId,
    int MechanicId,
    int ServiceTypeId,
    string Description,
    decimal HourlyCost,
    decimal HoursWorked,
    DateTime FechaInicio,
    DateTime FechaFin,
    string Status
) : IRequest<Guid>;