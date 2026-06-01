using System;
using Domain.Entities.Countries;
using MediatR;

namespace Application.UseCases.Countries;

public sealed record GetCountryById(
    Guid Id
) : IRequest<Country>;
