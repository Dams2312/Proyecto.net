using System;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed record GetMechanicTaskById(
    Guid Id
) : IRequest<MechanicTaskEntity>;

