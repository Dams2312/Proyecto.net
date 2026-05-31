using System;

namespace Domain.ValueObject.MileageHistory;

public sealed record MileageHistoryVehicleId
{
    public Guid Value { get; }

    private MileageHistoryVehicleId(Guid value)
    {
        Value = value;
    }

    public static MileageHistoryVehicleId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new MileageHistoryVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}