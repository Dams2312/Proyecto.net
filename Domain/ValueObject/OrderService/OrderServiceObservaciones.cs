using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceObservaciones
{
    public string? Value { get; }

    private OrderServiceObservaciones(string? value)
    {
        Value = value;
    }

    public static OrderServiceObservaciones Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new OrderServiceObservaciones((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("Las observaciones no pueden superar los 2000 caracteres.", nameof(value));

        return new OrderServiceObservaciones(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
