using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MileageHistory;
using Domain.ValueObject.MileageHistory;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed class UpdateMileageHistoryHandler
    : IRequestHandler<UpdateMileageHistory, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateMileageHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateMileageHistory request,
        CancellationToken ct)
    {
        var entity = await _uow.MileageHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MileageHistory no encontrado.");

        entity.UpdateVehicleId(MileageHistoryVehicleId.Create(request.VehicleId));
        entity.UpdateKilometraje(MileageHistoryKilometraje.Create(request.Kilometraje));
        entity.UpdateDate(MileageHistoryDate.Create(request.Date));
        entity.UpdateSource(MileageHistorySource.Create(request.Source));

        await _uow.MileageHistories.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
