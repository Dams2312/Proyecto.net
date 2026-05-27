using System;

namespace Domain.ValueObject.OrderStatus;

public sealed record OrderStatusName
{
    public string Value { get; }

    private OrderStatusName(string value)
    {
        Value = value;
    }

    public static OrderStatusName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del estado es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 50)
            throw new ArgumentException("El nombre del estado no puede superar los 50 caracteres.", nameof(value));

        return new OrderStatusName(value);
    }

    public override string ToString() => Value;
}
