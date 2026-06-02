using System;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed record GetMileageHistoryById(
    Guid Id
) : IRequest<MileageHistoryEntity>;

