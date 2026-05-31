using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailSparePartId
{
    public Guid Value { get; }

    private OrderDetailSparePartId(Guid value)
    {
        Value = value;
    }

    public static OrderDetailSparePartId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderDetailSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}