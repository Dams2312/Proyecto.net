using System;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record CreateCity(
    string Name,
    int CountryId,
    string Code
) : IRequest<Guid>;
