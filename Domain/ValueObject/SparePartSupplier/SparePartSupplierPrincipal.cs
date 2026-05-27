namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierPrincipal
{
    public bool Value { get; }

    private SparePartSupplierPrincipal(bool value)
    {
        Value = value;
    }

    public static SparePartSupplierPrincipal Create(bool value) => new(value);

    public override string ToString() => Value.ToString();
}
