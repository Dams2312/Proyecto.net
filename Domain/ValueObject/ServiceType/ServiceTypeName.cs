using System;

namespace Domain.ValueObject.ServiceType;

public sealed record ServiceTypeName
{
    public string Value { get; }

    private ServiceTypeName(string value)
    {
        Value = value;
    }

    public static ServiceTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del tipo de servicio es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 100)
            throw new ArgumentException("El nombre del tipo de servicio no puede superar los 100 caracteres.", nameof(value));

        return new ServiceTypeName(value);
    }

    public override string ToString() => Value;
}
