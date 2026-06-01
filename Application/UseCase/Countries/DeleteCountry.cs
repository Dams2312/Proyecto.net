using System;
using MediatR;

namespace Application.UseCases.Countries;

public sealed record DeleteCountry(
    Guid Id
) : IRequest<Unit>;
