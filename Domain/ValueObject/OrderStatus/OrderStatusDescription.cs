using System;

namespace Domain.ValueObject.OrderStatus;

public sealed record OrderStatusDescription
{
    public string? Value { get; }

    private OrderStatusDescription(string? value)
    {
        Value = value;
    }

    public static OrderStatusDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new OrderStatusDescription((string?)null);

        value = value.Trim();

        if (value.Length > 1000)
            throw new ArgumentException("La descripción no puede superar los 1000 caracteres.", nameof(value));

        return new OrderStatusDescription(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
