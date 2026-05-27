using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public class CustomerActive
{
    public bool Value { get; }

    private CustomerActive(bool value)
    {
        Value = value;
    }

    public static CustomerActive Create(bool value)
    {
        return new CustomerActive(value);
    }

    public override string ToString() => Value.ToString();  
}
