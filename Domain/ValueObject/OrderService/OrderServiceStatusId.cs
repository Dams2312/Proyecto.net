using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceStatusId
{
    public Guid Value { get; }

    private OrderServiceStatusId(Guid value)
    {
        Value = value;
    }

    public static OrderServiceStatusId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderServiceStatusId(value);
    }

    public override string ToString() => Value.ToString();
}