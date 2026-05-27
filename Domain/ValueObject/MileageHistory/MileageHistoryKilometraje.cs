using System;

namespace Domain.ValueObject.MileageHistory;

public sealed record MileageHistoryKilometraje
{
    public int Value { get; }

    private MileageHistoryKilometraje(int value)
    {
        Value = value;
    }

    public static MileageHistoryKilometraje Create(int value)
    {
        if (value < 0)
            throw new ArgumentException("El kilometraje no puede ser negativo.", nameof(value));

        return new MileageHistoryKilometraje(value);
    }

    public override string ToString() => Value.ToString();
}
