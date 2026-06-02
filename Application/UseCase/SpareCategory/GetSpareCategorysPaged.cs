using System.Collections.Generic;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed record GetSpareCategorysPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<SpareCategoryEntity>>;
