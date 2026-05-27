using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryObservacion
{
    public string? Value { get; }

    private OrderStatusHistoryObservacion(string? value)
    {
        Value = value;
    }

    public static OrderStatusHistoryObservacion Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new OrderStatusHistoryObservacion((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("La observación no puede superar los 2000 caracteres.", nameof(value));

        return new OrderStatusHistoryObservacion(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
