using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCase.MileageHistory;

public sealed record CreateMileageHistory(
    Guid VehicleId,
    int Kilometraje,
    DateOnly Date,
    string Source
) : IRequest<Guid>;

