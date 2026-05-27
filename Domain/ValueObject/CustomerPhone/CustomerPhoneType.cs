using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerPhone;

public sealed record CustomerPhoneType
{
    public string Value { get; }

    private CustomerPhoneType(string value)
    {
        Value = value;
    }

    public static CustomerPhoneType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El tipo de teléfono es obligatorio.", nameof(value));

        value = value.Trim().ToLower();

        if (value.Length > 20)
            throw new ArgumentException("El tipo de teléfono no puede superar los 20 caracteres.", nameof(value));

        string[] validTypes =
        [
            "celular",
            "fijo",
            "whatsapp",
            "otro"
        ];

        if (!validTypes.Contains(value))
            throw new ArgumentException("El tipo de teléfono no es válido.", nameof(value));

        return new CustomerPhoneType(value);
    }

    public override string ToString() => Value;   
}
