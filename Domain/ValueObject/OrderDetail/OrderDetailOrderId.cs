using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailOrderId
{
    public Guid Value { get; }

    private OrderDetailOrderId(Guid value)
    {
        Value = value;
    }

    public static OrderDetailOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderDetailOrderId(value);
    }

    public override string ToString() => Value.ToString();
}