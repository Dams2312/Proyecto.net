using System;

namespace Api.Dtos.CustomerAddress;

public sealed class CreateCustomerAddressRequest
{
    public Guid CustomerId { get; init; }
    public Guid CityId { get; init; }
    public string Street { get; init; } = default!;
    public bool Principal { get; init; }
}