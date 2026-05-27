using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Customer;

public sealed record CustomerRegistrationDate
{
    public DateOnly Value { get; }

    private CustomerRegistrationDate(DateOnly value)
    {
        Value = value;
    }

    public static CustomerRegistrationDate Create(DateOnly value)
    {
        if (value > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("La fecha de registro no puede ser futura.", nameof(value));

        return new CustomerRegistrationDate(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");  
}
