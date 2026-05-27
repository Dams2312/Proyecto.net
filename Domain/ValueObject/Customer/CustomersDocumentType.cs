using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public class CustomersDocumentType
{
    public string Value { get; }
    private CustomersDocumentType(string value)
    {
        Value = value;
    }
    public static CustomersDocumentType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El tipo de documento es obligatorio.", nameof(value));

        value = value.Trim().ToLower();

        if (value.Length > 20)
            throw new ArgumentException("El tipo de documento no puede superar los 20 caracteres.", nameof(value));

        string[] validTypes =
        [
            "cc",
            "ti",
            "ce",
            "nit",
            "pasaporte"
        ];

        if (!validTypes.Contains(value))
            throw new ArgumentException("El tipo de documento no es válido.", nameof(value));

        return new CustomersDocumentType(value);
    }

    public override string ToString() => Value;
}
