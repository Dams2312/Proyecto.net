using System;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record UpdateCity(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
