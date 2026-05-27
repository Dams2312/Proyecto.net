using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerEmail;

public sealed record CustomerEmailPrimary
{
    public bool Value { get; }

    private CustomerEmailPrimary(bool value)
    {
        Value = value;
    }

    public static CustomerEmailPrimary Create(bool value)
    {
        return new CustomerEmailPrimary(value);
    }

    public override string ToString() => Value.ToString();
}
