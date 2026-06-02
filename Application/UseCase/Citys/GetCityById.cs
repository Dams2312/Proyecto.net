using System;
using Domain.Entities.Citys;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed record GetCityById(
    Guid Id
) : IRequest<City>;

