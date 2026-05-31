using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersrolId
{
    public Guid Value { get; }
    private UsersrolId(Guid value)
    {
        Value = value;
    }
    public static UsersrolId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new UsersrolId(value);
    }
    public override string ToString() => Value.ToString();
}