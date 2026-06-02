using System;
using Domain.Entities.Countries;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed record GetCountryById(
    Guid Id
) : IRequest<Country>;

