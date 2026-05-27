using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskServiceTypeId
{
    public int? Value { get; }

    private MechanicTaskServiceTypeId(int? value)
    {
        Value = value;
    }

    public static MechanicTaskServiceTypeId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("El id del tipo de servicio debe ser mayor a 0.", nameof(value));

        return new MechanicTaskServiceTypeId(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}
