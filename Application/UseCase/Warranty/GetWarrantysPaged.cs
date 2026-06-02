using System.Collections.Generic;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed record GetWarrantysPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<WarrantyEntity>>;
