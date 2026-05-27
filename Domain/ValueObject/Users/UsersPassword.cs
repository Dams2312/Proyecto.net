using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersPassword
{
    public string Value { get; }
    private UsersPassword(string value)
    {
        Value = value;
    }
    public static UsersPassword Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La contraseña es obligatoria.", nameof(value));

        if (value.Length < 6)
            throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", nameof(value));

        return new UsersPassword(value);
    }
    public override string ToString() => Value;
}
