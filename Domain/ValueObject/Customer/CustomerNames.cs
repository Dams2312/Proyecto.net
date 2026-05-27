using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public sealed record CustomerNames
{
    public string Value { get; }
    private CustomerNames(string value)
    {
        Value = value;
    }
    public static CustomerNames Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El apellido es obligatorio.", nameof(value));
        if (value.Length < 2)
            throw new ArgumentException("El apellido debe tener al menos 2 caracteres.", nameof(value));

        return new CustomerNames(value);
    }
    public override string ToString() => Value;
}
