using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.City;

public sealed record CityCountryId
{
    public int Value { get; }

    private CityCountryId(int value)
    {
        Value = value;
    }

    public static CityCountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El ID del país debe ser un número positivo.", nameof(value));

        return new CityCountryId(value);
    }

    public override string ToString() => Value.ToString();
}
