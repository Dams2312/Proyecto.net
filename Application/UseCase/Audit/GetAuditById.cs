using System;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed record GetAuditById(
    Guid Id
) : IRequest<AuditEntity>;

