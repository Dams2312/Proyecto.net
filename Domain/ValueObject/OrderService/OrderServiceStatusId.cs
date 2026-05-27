using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceStatusId
{
    public int Value { get; }

    private OrderServiceStatusId(int value)
    {
        Value = value;
    }

    public static OrderServiceStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del estado debe ser mayor a 0.", nameof(value));

        return new OrderServiceStatusId(value);
    }

    public override string ToString() => Value.ToString();
}
