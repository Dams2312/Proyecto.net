using System.Collections.Generic;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed record GetSparePartsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<SparePartEntity>>;
