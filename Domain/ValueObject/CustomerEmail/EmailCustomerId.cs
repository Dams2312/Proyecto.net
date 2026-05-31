using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerEmail;

public sealed record EmailCustomerId
{
    public Guid Value { get; }

    private EmailCustomerId(Guid value)
    {
        Value = value;
    }

    public static EmailCustomerId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new EmailCustomerId(value);
    }

    public override string ToString() => Value.ToString();
}