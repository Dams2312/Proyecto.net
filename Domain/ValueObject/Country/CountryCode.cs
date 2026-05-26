using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Country;

public sealed record CountryCode
{
    public string Value { get; }

    private CountryCode(string value)
    {
        Value = value;
    }

    public static CountryCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código del país es obligatorio.", nameof(value));

        var normalized = value.Trim();

        if (normalized.Length != 3)
            throw new ArgumentException("El código del país debe tener exactamente 3 caracteres.", nameof(value));

        return new CountryCode(normalized);
    }

    public override string ToString() => Value;
}
