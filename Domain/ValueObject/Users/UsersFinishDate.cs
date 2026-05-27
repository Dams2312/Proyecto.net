using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersFinishDate
{
    public DateTime Value { get; }
    private UsersFinishDate(DateTime value)
    {
        Value = value;
    }
    public static UsersFinishDate Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de finalización es obligatoria.", nameof(value));

        return new UsersFinishDate(value);
    }
}
