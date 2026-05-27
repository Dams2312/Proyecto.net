using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public class UsersActive
{
    public bool Value { get; }
    private UsersActive(bool value)
    {
        Value = value;
    }
    public static UsersActive Create(bool value)
    {
        return new UsersActive(value);
    }
}
