using System;
using MediatR;
using City = Domain.Entities.Citys.City;

namespace Application.UseCase.Citys;

public sealed record DeleteCity(
    Guid Id
) : IRequest<Unit>;

