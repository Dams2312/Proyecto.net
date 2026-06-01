using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record CreateMileageHistory(
    int VehicleId,
    int Kilometraje,
    DateOnly Date,
    string Source
) : IRequest<Guid>;
