using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public class CustomersSurnames
{
    public string Value { get; }
    private CustomersSurnames(string value)
    {
        Value = value;
    }
    public static CustomersSurnames Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El apellido es obligatorio.", nameof(value));

        if (value.Length < 2)
            throw new ArgumentException("El apellido debe tener al menos 2 caracteres.", nameof(value));

        return new CustomersSurnames(value);
    }
    public override string ToString() => Value;
}
