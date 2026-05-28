using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.MileageHistory;

namespace Domain.Entities.MileageHistory;

public sealed class MileageHistory : BaseEntity<Guid>
{
    public MileageHistoryVehicleId VehicleId { get; private set; }
    public MileageHistoryKilometraje Kilometraje { get; private set; }
    public MileageHistoryDate Date { get; private set; }
    public MileageHistorySource Source { get; private set; }

    private MileageHistory() { }

    public MileageHistory(
        MileageHistoryVehicleId vehicleId,
        MileageHistoryKilometraje kilometraje,
        MileageHistoryDate date,
        MileageHistorySource source)
    {
        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
        Kilometraje = kilometraje ?? throw new ArgumentNullException(nameof(kilometraje));
        Date = date ?? throw new ArgumentNullException(nameof(date));
        Source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public void UpdateVehicleId(MileageHistoryVehicleId vehicleId)
    {
        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
    }

    public void UpdateKilometraje(MileageHistoryKilometraje kilometraje)
    {
        Kilometraje = kilometraje ?? throw new ArgumentNullException(nameof(kilometraje));
    }

    public void UpdateDate(MileageHistoryDate date)
    {
        Date = date ?? throw new ArgumentNullException(nameof(date));
    }

    public void UpdateSource(MileageHistorySource source)
    {
        Source = source ?? throw new ArgumentNullException(nameof(source));
    }
}
