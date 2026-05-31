using System;

namespace Domain.ValueObject.PurchaseDetail;

public sealed record PurchaseDetailSparePartId
{
    public Guid Value { get; }

    private PurchaseDetailSparePartId(Guid value)
    {
        Value = value;
    }

    public static PurchaseDetailSparePartId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new PurchaseDetailSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}