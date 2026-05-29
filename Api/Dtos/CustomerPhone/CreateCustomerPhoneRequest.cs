using System;

namespace Api.Dtos.CustomerPhone;

public sealed class CreateCustomerPhoneRequest
{
    public string Phone { get; init; } = default!;
    public string Type { get; init; } = default!;
}
