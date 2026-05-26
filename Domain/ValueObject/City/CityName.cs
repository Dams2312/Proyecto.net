using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.City;

public sealed record CityName
{
    public string Value { get; }
    private CityName(string value)
    {
        Value = value;
    }
    public static CityName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la ciudad es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length > 100)
            throw new ArgumentException("El nombre de la ciudad no puede tener más de 100 caracteres.", nameof(value));

        return new CityName(normalized);
    }
    public override string ToString() => Value;
}
