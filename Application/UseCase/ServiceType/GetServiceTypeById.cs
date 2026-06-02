using System;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed record GetServiceTypeById(Guid Id) : IRequest<ServiceTypeEntity>;
