using System;

namespace Domain.ValueObject.MileageHistory;

public sealed record MileageHistoryDate
{
    public DateOnly Value { get; }

    private MileageHistoryDate(DateOnly value)
    {
        Value = value;
    }

    public static MileageHistoryDate Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha es obligatoria.", nameof(value));

        return new MileageHistoryDate(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
