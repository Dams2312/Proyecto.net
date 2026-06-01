using System;
using MediatR;

namespace Application.UseCases.Countries;

public sealed record UpdateCountry(
    Guid Id,
    string Name,
    string Code
) : IRequest<Unit>;
