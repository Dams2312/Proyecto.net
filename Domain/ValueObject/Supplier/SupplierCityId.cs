using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierCityId
{
    public Guid Value { get; }

    private SupplierCityId(Guid value)
    {
        Value = value;
    }

    public static SupplierCityId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id de la ciudad es obligatorio.", nameof(value));

        return new SupplierCityId(value);
    }

    public override string ToString() => Value.ToString();
}