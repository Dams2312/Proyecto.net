using System;
using MediatR;

namespace Application.UseCases.Audit;

public sealed record DeleteAudit(
    Guid Id
) : IRequest<Unit>;
