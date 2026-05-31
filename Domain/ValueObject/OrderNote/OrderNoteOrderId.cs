using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteOrderId
{
    public Guid Value { get; }

    private OrderNoteOrderId(Guid value)
    {
        Value = value;
    }

    public static OrderNoteOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderNoteOrderId(value);
    }

    public override string ToString() => Value.ToString();
}