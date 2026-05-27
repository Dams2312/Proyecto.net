using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailPriceSnapshot
{
    public decimal Value { get; }

    private OrderDetailPriceSnapshot(decimal value)
    {
        Value = value;
    }

    public static OrderDetailPriceSnapshot Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El precio snapshot no puede ser negativo.", nameof(value));

        return new OrderDetailPriceSnapshot(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
