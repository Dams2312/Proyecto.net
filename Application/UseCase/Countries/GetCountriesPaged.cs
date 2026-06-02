using System.Collections.Generic;
using Domain.Entities.Countries;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed record GetCountriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Country>>;

