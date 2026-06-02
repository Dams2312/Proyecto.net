using System;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed record UpdateAudit(
    Guid Id,
    string Entity,
    DateTime Date,
    string ActionType,
    string? PreviousData,
    string? NewData,
    string? IpOrigin
) : IRequest<Unit>;

