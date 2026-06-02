namespace Api.Dtos.CustomerAddress;

public sealed class CustomerAddressDto
{
    public Guid Id { get; init; }
    public Guid CityId { get; init; }
    public string Street { get; init; } = default!;
    public bool Principal { get; init; }
}
