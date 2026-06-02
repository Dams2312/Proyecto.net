using System;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

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

