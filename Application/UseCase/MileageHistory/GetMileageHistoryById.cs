using System;
using Domain.Entities.MileageHistory;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record GetMileageHistoryById(
    Guid Id
) : IRequest<MileageHistory>;
