using System;
using MediatR;

namespace Application.UseCase.SpareCategory;

public sealed record UpdateSpareCategory(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;
