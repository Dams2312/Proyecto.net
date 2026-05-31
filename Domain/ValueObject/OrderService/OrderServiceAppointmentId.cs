using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceAppointmentId
{
    public int? Value { get; }

    private OrderServiceAppointmentId(int? value)
    {
        Value = value;
    }

    public static OrderServiceAppointmentId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("El id de la cita debe ser mayor a 0.", nameof(value));

        return new OrderServiceAppointmentId(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}