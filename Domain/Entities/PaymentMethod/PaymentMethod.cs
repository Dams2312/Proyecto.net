using System;
using Domain.common;
using Domain.ValueObject.PaymentMethod;

namespace Domain.Entities.PaymentMethod;

public sealed class PaymentMethod : BaseEntity<Guid>
{
    public PaymentMethodName Name { get; private set; }
    public PaymentMethodDescription? Description { get; private set; }

    private PaymentMethod() { }

    public PaymentMethod(PaymentMethodName name, PaymentMethodDescription? description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description;
    }

    public void UpdateName(PaymentMethodName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateDescription(PaymentMethodDescription? description)
    {
        Description = description;
    }
}
