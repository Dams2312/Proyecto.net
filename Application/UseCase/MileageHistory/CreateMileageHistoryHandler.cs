using Application.Abstractions;
using Domain.Entities.MileageHistory;
using Domain.ValueObject.MileageHistory;
using MediatR;
using MileageHistoryEntity = Domain.Entities.MileageHistory.MileageHistory;

namespace Application.UseCases.MileageHistory;

public sealed class CreateMileageHistoryHandler
    : IRequestHandler<CreateMileageHistory, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateMileageHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateMileageHistory request,
        CancellationToken ct)
    {
        var vehicleId = MileageHistoryVehicleId.Create(request.VehicleId);

        var kilometraje = MileageHistoryKilometraje.Create(request.Kilometraje);

        var date = MileageHistoryDate.Create(request.Date);

        var source = MileageHistorySource.Create(request.Source);

        var mileageHistory = new MileageHistoryEntity(
            vehicleId,
            kilometraje,
            date,
            source);

        await _uow.MileageHistories.AddAsync(mileageHistory, ct);

        await _uow.SaveChangesAsync(ct);

        return mileageHistory.Id;
    }
}