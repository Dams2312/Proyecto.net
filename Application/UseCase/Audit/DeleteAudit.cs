using System;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed record DeleteAudit(
    Guid Id
) : IRequest<Unit>;

