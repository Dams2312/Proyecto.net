using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceKilometrajeIngreso
{
    public int Value { get; }

    private OrderServiceKilometrajeIngreso(int value)
    {
        Value = value;
    }

    public static OrderServiceKilometrajeIngreso Create(int value)
    {
        if (value < 0)
            throw new ArgumentException("El kilometraje de ingreso no puede ser negativo.", nameof(value));

        return new OrderServiceKilometrajeIngreso(value);
    }

    public override string ToString() => Value.ToString();
}
