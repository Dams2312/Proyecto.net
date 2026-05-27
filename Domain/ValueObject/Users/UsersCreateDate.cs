using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public class UsersCreateDate
{
    public DateTime Value { get; }
    private UsersCreateDate(DateTime value)
    {
        Value = value;
    }
    public static UsersCreateDate Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de creación es obligatoria.", nameof(value));

        return new UsersCreateDate(value);
    }
}
