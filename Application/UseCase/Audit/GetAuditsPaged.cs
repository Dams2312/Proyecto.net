using System.Collections.Generic;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed record GetAuditsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<AuditEntity>>;

