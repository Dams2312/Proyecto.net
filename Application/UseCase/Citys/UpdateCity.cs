using System;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed record UpdateCity(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;

