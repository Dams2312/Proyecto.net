using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersSurnames
{
    public string Value { get; }
    private UsersSurnames(string value)
    {
        Value = value;
    }
    public static UsersSurnames Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El apellido es obligatorio.", nameof(value));

        if (value.Length < 2)
            throw new ArgumentException("El apellido debe tener al menos 2 caracteres.", nameof(value));

        return new UsersSurnames(value);
    }
    public override string ToString() => Value;
}
