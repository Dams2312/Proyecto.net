using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceImpuestoPct
{
    public decimal Value { get; }

    private InvoiceImpuestoPct(decimal value)
    {
        Value = value;
    }

    public static InvoiceImpuestoPct Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El porcentaje de impuesto no puede ser negativo.", nameof(value));

        return new InvoiceImpuestoPct(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
