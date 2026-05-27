using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteOrderId
{
    public int Value { get; }

    private OrderNoteOrderId(int value)
    {
        Value = value;
    }

    public static OrderNoteOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new OrderNoteOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
