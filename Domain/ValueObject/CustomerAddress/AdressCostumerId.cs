using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record AddressCustomerId
{
    public Guid Value { get; }

    private AddressCustomerId(Guid value)
    {
        Value = value;
    }

    public static AddressCustomerId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new AddressCustomerId(value);
    }

    public override string ToString() => Value.ToString();  
}