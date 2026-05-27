using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceManoDeObra
{
    public decimal Value { get; }

    private InvoiceManoDeObra(decimal value)
    {
        Value = value;
    }

    public static InvoiceManoDeObra Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("La mano de obra no puede ser negativa.", nameof(value));

        return new InvoiceManoDeObra(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
