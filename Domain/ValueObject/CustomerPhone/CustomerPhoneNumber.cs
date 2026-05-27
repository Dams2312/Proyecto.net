using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerPhone;

public sealed record CustomerPhoneNumber
{
    public string Value { get; }

    private CustomerPhoneNumber(string value)
    {
        Value = value;
    }

    public static CustomerPhoneNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El teléfono es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 20)
            throw new ArgumentException("El teléfono no puede superar los 20 caracteres.", nameof(value));

        if (!Regex.IsMatch(value, @"^[0-9+\-\s]+$"))
            throw new ArgumentException("El teléfono contiene caracteres inválidos.", nameof(value));

        return new CustomerPhoneNumber(value);
    }

    public override string ToString() => Value; 
}
