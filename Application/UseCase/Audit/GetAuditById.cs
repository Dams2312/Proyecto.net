using System;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;

namespace Application.UseCases.Audit;

public sealed record GetAuditById(
    Guid Id
) : IRequest<AuditEntity>;
