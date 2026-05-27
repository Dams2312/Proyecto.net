using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceCostoRepuestos
{
    public decimal Value { get; }

    private InvoiceCostoRepuestos(decimal value)
    {
        Value = value;
    }

    public static InvoiceCostoRepuestos Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El costo de repuestos no puede ser negativo.", nameof(value));

        return new InvoiceCostoRepuestos(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
