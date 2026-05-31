using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerPhone;

public sealed record PhoneCustomerId
{
    public Guid Value { get; }

    private PhoneCustomerId(Guid value)
    {
        Value = value;
    }

    public static PhoneCustomerId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new PhoneCustomerId(value);
    }

    public override string ToString() => Value.ToString(); 
}