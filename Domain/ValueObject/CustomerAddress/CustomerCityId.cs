using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record CustomerCityId
{
    public int Value { get; }

    private CustomerCityId(int value)
    {
        Value = value;
    }

    public static CustomerCityId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la ciudad debe ser mayor a 0.", nameof(value));

        return new CustomerCityId(value);
    }

    public override string ToString() => Value.ToString();
}
