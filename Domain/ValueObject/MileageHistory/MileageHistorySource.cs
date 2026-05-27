using System;

namespace Domain.ValueObject.MileageHistory;

public sealed record MileageHistorySource
{
    public string Value { get; }

    private MileageHistorySource(string value)
    {
        Value = value;
    }

    public static MileageHistorySource Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La fuente es obligatoria.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized is not ("ingreso_orden" or "cita" or "actualizacion_manual"))
            throw new ArgumentException("La fuente no es válida.", nameof(value));

        return new MileageHistorySource(normalized);
    }

    public override string ToString() => Value;
}
