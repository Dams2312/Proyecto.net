using System;
using MediatR;

namespace Application.UseCase.ServiceType;

public sealed record CreateServiceType(
    string Name,
    string Description,
    int EstimatedDays
) : IRequest<Guid>;
