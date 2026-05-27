using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierCityId
{
    public int? Value { get; }

    private SupplierCityId(int? value)
    {
        Value = value;
    }

    public static SupplierCityId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("El id de la ciudad debe ser mayor a 0.", nameof(value));

        return new SupplierCityId(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}
