using System;

namespace Domain.ValueObject.ServiceType;

public sealed record ServiceTypeDescription
{
    public string? Value { get; }

    private ServiceTypeDescription(string? value)
    {
        Value = value;
    }

    public static ServiceTypeDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new ServiceTypeDescription((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("La descripción no puede superar los 2000 caracteres.", nameof(value));

        return new ServiceTypeDescription(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
