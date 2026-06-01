using System;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record DeleteCity(
    Guid Id
) : IRequest<Unit>;
