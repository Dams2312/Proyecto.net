using System.Collections.Generic;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed record GetServiceTypesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<ServiceTypeEntity>>;
