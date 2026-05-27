using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerPhone;

public sealed record PhoneCustomerId
{
    public int Value { get; }

    private PhoneCustomerId(int value)
    {
        Value = value;
    }

    public static PhoneCustomerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del cliente debe ser mayor a 0.", nameof(value));

        return new PhoneCustomerId(value);
    }

    public override string ToString() => Value.ToString(); 
}
