using System.Collections.Generic;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;

namespace Application.UseCases.Audit;

public sealed record GetAuditsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<AuditEntity>>;
