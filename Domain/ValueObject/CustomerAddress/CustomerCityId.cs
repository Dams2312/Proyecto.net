using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record CustomerCityId
{
    public Guid Value { get; }

    private CustomerCityId(Guid value)
    {
        Value = value;
    }

    public static CustomerCityId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new CustomerCityId(value);
    }

    public override string ToString() => Value.ToString();
}