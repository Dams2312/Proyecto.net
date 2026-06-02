using System;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed record CreateCity(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;

