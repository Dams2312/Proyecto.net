using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Vehicle;

namespace Domain.Entities.Vehicle;

public sealed class Vehicle : BaseEntity<Guid>
{
    public VehicleClientId ClientId { get; private set; }
    public VehicleModelId ModelId { get; private set; }
    public VehicleVin Vin { get; private set; }
    public VehiclePlate Plate { get; private set; }
    public VehicleYear Year { get; private set; }
    public VehicleColor Color { get; private set; }
    public VehicleActive Active { get; private set; }

    private Vehicle() { }

    public Vehicle(
        VehicleClientId clientId,
        VehicleModelId modelId,
        VehicleVin vin,
        VehiclePlate plate,
        VehicleYear year,
        VehicleColor color,
        VehicleActive active)
    {
        ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        ModelId = modelId ?? throw new ArgumentNullException(nameof(modelId));
        Vin = vin ?? throw new ArgumentNullException(nameof(vin));
        Plate = plate ?? throw new ArgumentNullException(nameof(plate));
        Year = year ?? throw new ArgumentNullException(nameof(year));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }

    public void UpdateClientId(VehicleClientId clientId)
    {
        ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
    }

    public void UpdateModelId(VehicleModelId modelId)
    {
        ModelId = modelId ?? throw new ArgumentNullException(nameof(modelId));
    }

    public void UpdateVin(VehicleVin vin)
    {
        Vin = vin ?? throw new ArgumentNullException(nameof(vin));
    }

    public void UpdatePlate(VehiclePlate plate)
    {
        Plate = plate ?? throw new ArgumentNullException(nameof(plate));
    }

    public void UpdateYear(VehicleYear year)
    {
        Year = year ?? throw new ArgumentNullException(nameof(year));
    }

    public void UpdateColor(VehicleColor color)
    {
        Color = color ?? throw new ArgumentNullException(nameof(color));
    }

    public void UpdateActive(VehicleActive active)
    {
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }
}
