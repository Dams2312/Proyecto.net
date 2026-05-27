using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record AddressCustomerId
{
    public int Value { get; }

    private AddressCustomerId(int value)
    {
        Value = value;
    }

    public static AddressCustomerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del cliente debe ser mayor a 0.", nameof(value));

        return new AddressCustomerId(value);
    }

    public override string ToString() => Value.ToString();  
}
