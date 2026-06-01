using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record CreateMileageHistory(
    Guid VehicleId,
    int Kilometraje,
    DateOnly Date,
    string Source
) : IRequest<Guid>;
