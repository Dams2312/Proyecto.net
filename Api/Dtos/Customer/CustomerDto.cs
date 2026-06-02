using Api.Dtos.CustomerPhone;
using Api.Dtos.CustomerEmail;
using Api.Dtos.CustomerAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Customer;

public sealed class CustomerDto
{
    public Guid Id { get; init; }

    public string Names { get; init; } = default!;

    public string LastNames { get; init; } = default!;

    public List<CustomerPhoneDto> Phones { get; init; } = [];

    public List<CustomerEmailDto> Emails { get; init; } = [];

    public List<CustomerAddressDto> Addresses { get; init; } = [];
}
