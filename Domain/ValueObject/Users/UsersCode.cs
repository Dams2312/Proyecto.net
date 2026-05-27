using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersCode
{
    public string Value { get; }
    private UsersCode(string value)
    {
        Value = value;
    }
    public static UsersCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código es obligatorio.", nameof(value));

        if (value.Length < 2)
            throw new ArgumentException("El código debe tener al menos 2 caracteres.", nameof(value));

        return new UsersCode(value);
    }
    public override string ToString() => Value;
}
