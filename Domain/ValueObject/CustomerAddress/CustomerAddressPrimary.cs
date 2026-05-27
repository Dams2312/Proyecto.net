using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerAddress;

public sealed record CustomerAddressPrimary
{
    public bool Value { get; }

    private CustomerAddressPrimary(bool value)
    {
        Value = value;
    }

    public static CustomerAddressPrimary Create(bool value)
    {
        return new CustomerAddressPrimary(value);
    }

    public override string ToString() => Value.ToString();  
}
