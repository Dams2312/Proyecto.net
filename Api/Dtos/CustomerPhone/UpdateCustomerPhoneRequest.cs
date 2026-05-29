using System;

namespace Api.Dtos.CustomerPhone;

public sealed class UpdateCustomerPhoneRequest
{
    public Guid Id { get; init; }

    public string Phone { get; init; } = default!;

    public string Type { get; init; } = default!;
}
