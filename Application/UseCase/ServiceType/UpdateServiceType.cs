using System;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed record UpdateServiceType(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
