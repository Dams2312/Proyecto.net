using System;
using MediatR;

namespace Application.UseCases.Countries;

public sealed record CreateCountry(
    string Name,
    string Code
) : IRequest<Guid>;
