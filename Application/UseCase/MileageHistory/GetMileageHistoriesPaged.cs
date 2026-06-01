using System.Collections.Generic;
using Domain.Entities.MileageHistory;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record GetMileageHistoriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<MileageHistory>>;
