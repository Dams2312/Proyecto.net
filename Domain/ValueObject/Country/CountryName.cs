using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Country;

public sealed record CountryName
{
    public string Value { get; }

    private CountryName(string value)
    {
        Value = value;
    }
    public static CountryName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del país es obligatorio.", nameof(value));

        var normalized = value.Trim();

        if (normalized.Length < 2 || normalized.Length > 100)
            throw new ArgumentException("El nombre del país debe tener entre 2 y 100 caracteres.", nameof(value));

        return new CountryName(normalized);
    }
    public override string ToString() => Value;
}
