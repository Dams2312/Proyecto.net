using System.Collections.Generic;
using Domain.Entities.Citys;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed record GetCitysPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<City>>;

