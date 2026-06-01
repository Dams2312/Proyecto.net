using System.Collections.Generic;
using Domain.Entities.Citys;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record GetCitysPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<City>>;
