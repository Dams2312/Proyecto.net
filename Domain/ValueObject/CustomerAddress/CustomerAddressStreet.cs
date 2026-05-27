using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record CustomerAddressStreet
{
    public string Value { get; }

    private CustomerAddressStreet(string value)
    {
        Value = value;
    }

    public static CustomerAddressStreet Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La dirección es obligatoria.", nameof(value));

        value = value.Trim();

        if (value.Length > 255)
            throw new ArgumentException("La dirección no puede superar los 255 caracteres.", nameof(value));

        return new CustomerAddressStreet(value);
    }

    public override string ToString() => Value;  
}
