using System;

namespace Domain.ValueObject.MileageHistory;

public sealed record MileageHistoryVehicleId
{
    public int Value { get; }

    private MileageHistoryVehicleId(int value)
    {
        Value = value;
    }

    public static MileageHistoryVehicleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del vehículo debe ser mayor a 0.", nameof(value));

        return new MileageHistoryVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}
