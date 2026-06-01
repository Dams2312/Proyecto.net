using System;
using Domain.Entities.Citys;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record GetCityById(
    Guid Id
) : IRequest<City>;
