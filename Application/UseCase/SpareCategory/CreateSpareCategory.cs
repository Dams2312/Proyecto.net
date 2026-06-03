using System;
using MediatR;

namespace Application.UseCase.SpareCategory;

public sealed record CreateSpareCategory(
    string Name,
    string Description
) : IRequest<Guid>;
