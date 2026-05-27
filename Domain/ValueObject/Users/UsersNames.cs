using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersNames
{
    public string Value { get; }
    private UsersNames(string value)
    {
        Value = value;
    }
    public static UsersNames Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre es obligatorio.", nameof(value));

        if (value.Length < 2)
            throw new ArgumentException("El nombre debe tener al menos 2 caracteres.", nameof(value));

        return new UsersNames(value);
    }
    public override string ToString() => Value;
}
