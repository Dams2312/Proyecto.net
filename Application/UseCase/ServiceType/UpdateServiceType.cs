using System;
using MediatR;

namespace Application.UseCase.ServiceType;

public sealed record UpdateServiceType(
    Guid Id,
    string Name,
    string Description,
    int EstimatedDays
) : IRequest<Unit>;
