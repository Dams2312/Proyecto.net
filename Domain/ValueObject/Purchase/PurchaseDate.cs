using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseDate
{
    public DateOnly Value { get; }

    private PurchaseDate(DateOnly value)
    {
        Value = value;
    }

    public static PurchaseDate Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de compra es obligatoria.", nameof(value));

        return new PurchaseDate(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
