using System;
using MediatR;
using Country = Domain.Entities.Countries.Country;

namespace Application.UseCase.Countries;

public sealed record DeleteCountry(
    Guid Id
) : IRequest<Unit>;

