using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceReceptionistId
{
    public Guid Value { get; }

    private OrderServiceReceptionistId(Guid value)
    {
        Value = value;
    }

    public static OrderServiceReceptionistId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderServiceReceptionistId(value);
    }

    public override string ToString() => Value.ToString();
}