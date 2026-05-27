using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public class CustomerDocumentNumber
{
    public string Value { get; }

    private CustomerDocumentNumber(string value)
    {
        Value = value;
    }

    public static CustomerDocumentNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El número de documento es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 30)
            throw new ArgumentException("El número de documento no puede superar los 30 caracteres.", nameof(value));

        if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\-]+$"))
            throw new ArgumentException("El número de documento contiene caracteres inválidos.", nameof(value));

        return new CustomerDocumentNumber(value);
    }

    public override string ToString() => Value;
}
