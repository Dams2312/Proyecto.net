using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerEmail;

public sealed record EmailCustomerId
{
    public int Value { get; }

    private EmailCustomerId(int value)
    {
        Value = value;
    }

    public static EmailCustomerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del cliente debe ser mayor a 0.", nameof(value));

        return new EmailCustomerId(value);
    }

    public override string ToString() => Value.ToString();
}    

