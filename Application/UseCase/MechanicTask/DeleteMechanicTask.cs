using System;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record DeleteMechanicTask(
    Guid Id
) : IRequest<Unit>;
