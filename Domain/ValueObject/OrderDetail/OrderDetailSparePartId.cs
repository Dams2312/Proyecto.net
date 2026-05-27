using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailSparePartId
{
    public int Value { get; }

    private OrderDetailSparePartId(int value)
    {
        Value = value;
    }

    public static OrderDetailSparePartId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del repuesto debe ser mayor a 0.", nameof(value));

        return new OrderDetailSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}
