namespace Domain.ValueObject.Supplier;

public sealed record SupplierActive
{
    public bool Value { get; }

    private SupplierActive(bool value)
    {
        Value = value;
    }

    public static SupplierActive Create(bool value) => new(value);

    public override string ToString() => Value.ToString();
}
