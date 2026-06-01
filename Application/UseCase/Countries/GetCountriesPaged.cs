using System.Collections.Generic;
using Domain.Entities.Countries;
using MediatR;

namespace Application.UseCases.Countries;

public sealed record GetCountriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Country>>;
