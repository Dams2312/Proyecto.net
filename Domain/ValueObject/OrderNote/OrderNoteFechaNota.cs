using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteFechaNota
{
    public DateTime Value { get; }

    private OrderNoteFechaNota(DateTime value)
    {
        Value = value;
    }

    public static OrderNoteFechaNota Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de la nota es obligatoria.", nameof(value));

        return new OrderNoteFechaNota(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}
