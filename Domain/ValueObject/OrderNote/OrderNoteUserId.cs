using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteUserId
{
    public Guid Value { get; }

    private OrderNoteUserId(Guid value)
    {
        Value = value;
    }

    public static OrderNoteUserId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderNoteUserId(value);
    }

    public override string ToString() => Value.ToString();
}