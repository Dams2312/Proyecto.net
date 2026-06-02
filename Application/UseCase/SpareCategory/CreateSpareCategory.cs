using System;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed record CreateSpareCategory(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
