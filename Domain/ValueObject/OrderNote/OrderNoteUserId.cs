using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteUserId
{
    public int Value { get; }

    private OrderNoteUserId(int value)
    {
        Value = value;
    }

    public static OrderNoteUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del usuario debe ser mayor a 0.", nameof(value));

        return new OrderNoteUserId(value);
    }

    public override string ToString() => Value.ToString();
}
