namespace Domain.ValueObject.Vehicle;

public sealed record VehicleActive
{
    public bool Value { get; }

    private VehicleActive(bool value)
    {
        Value = value;
    }

    public static VehicleActive Create(bool value) => new(value);

    public override string ToString() => Value.ToString();
}
