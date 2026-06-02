using Api.Dtos.CustomerPhone;
using Api.Dtos.CustomerEmail;
using Api.Dtos.CustomerAddress;
using System;

namespace Api.Dtos.Customer;

public sealed class CreateCustomerRequest
{
    public string Names { get; init; } = default!;

    public string LastNames { get; init; } = default!;

    public string DocumentType { get; init; } = default!;

    public string DocumentNumber { get; init; } = default!;

    public List<CreateCustomerPhoneRequest> Phones { get; init; } = [];

    public List<CreateCustomerEmailRequest> Emails { get; init; } = [];

    public List<CreateCustomerAddressRequest> Addresses { get; init; } = [];
}
