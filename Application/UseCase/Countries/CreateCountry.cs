using System;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed record CreateCountry(
    string Name,
    string Code
) : IRequest<Guid>;

