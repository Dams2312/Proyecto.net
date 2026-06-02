using System;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed record DeleteMileageHistory(
    Guid Id
) : IRequest<Unit>;

