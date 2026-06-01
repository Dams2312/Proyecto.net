using System;
using MediatR;

namespace Application.UseCases.Audit;

public sealed record UpdateAudit(
    Guid Id,
    string Entity,
    DateTime Date,
    string ActionType,
    string? PreviousData,
    string? NewData,
    string? IpOrigin
) : IRequest<Unit>;
