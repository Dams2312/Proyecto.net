using System;

namespace Api.Dtos.Customer;

public sealed class UpdateCustomerRequest
{
    public string Names { get; init; } = default!;

    public string LastNames { get; init; } = default!;

    public bool Active { get; init; }

    public List<UpdateCustomerPhoneRequest> Phones { get; init; } = [];

    public List<UpdateCustomerEmailRequest> Emails { get; init; } = [];

    public List<UpdateCustomerAddressRequest> Addresses { get; init; } = [];
}
