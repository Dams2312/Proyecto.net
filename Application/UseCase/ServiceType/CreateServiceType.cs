using System;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed record CreateServiceType(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
