using System;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed record DeleteMechanicTask(
    Guid Id
) : IRequest<Unit>;

