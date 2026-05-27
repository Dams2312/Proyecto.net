using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceReceptionistId
{
    public int Value { get; }

    private OrderServiceReceptionistId(int value)
    {
        Value = value;
    }

    public static OrderServiceReceptionistId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del recepcionista debe ser mayor a 0.", nameof(value));

        return new OrderServiceReceptionistId(value);
    }

    public override string ToString() => Value.ToString();
}
