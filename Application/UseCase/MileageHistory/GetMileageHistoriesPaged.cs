using System.Collections.Generic;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed record GetMileageHistoriesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<MileageHistoryEntity>>;

