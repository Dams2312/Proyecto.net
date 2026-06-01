using System;
using Domain.Entities.MechanicTask;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record GetMechanicTaskById(
    Guid Id
) : IRequest<MechanicTask>;
