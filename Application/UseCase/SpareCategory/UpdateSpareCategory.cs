using System;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed record UpdateSpareCategory(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
