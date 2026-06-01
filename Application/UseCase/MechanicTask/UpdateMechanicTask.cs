using System;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record UpdateMechanicTask(
    Guid Id,
    Guid OrderId,
    Guid MechanicId,
    Guid ServiceTypeId,
    string Description,
    decimal HourlyCost,
    decimal HoursWorked,
    DateTime FechaInicio,
    DateTime FechaFin,
    string Status
) : IRequest<Unit>;
