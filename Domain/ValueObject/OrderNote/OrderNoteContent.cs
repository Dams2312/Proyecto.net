using System;

namespace Domain.ValueObject.OrderNote;

public sealed record OrderNoteContent
{
    public string Value { get; }

    private OrderNoteContent(string value)
    {
        Value = value;
    }

    public static OrderNoteContent Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El contenido es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 4000)
            throw new ArgumentException("El contenido no puede superar los 4000 caracteres.", nameof(value));

        return new OrderNoteContent(value);
    }

    public override string ToString() => Value;
}
