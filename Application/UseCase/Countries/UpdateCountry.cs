using System;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed record UpdateCountry(
    Guid Id,
    string Name,
    string Code
) : IRequest<Unit>;

