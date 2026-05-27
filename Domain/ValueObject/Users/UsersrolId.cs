using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersrolId
{
    public int Value { get; }
    private UsersrolId(int value)
    {
        Value = value;
    }
    public static UsersrolId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El ID del rol de usuario debe ser un número positivo.", nameof(value));

        return new UsersrolId(value);
    }
    public override string ToString() => Value.ToString();
}
