namespace Domain.ValueObject.SparePart;

public sealed record SparePartActive
{
    public bool Value { get; }

    private SparePartActive(bool value)
    {
        Value = value;
    }

    public static SparePartActive Create(bool value) => new(value);

    public override string ToString() => Value.ToString();
}
