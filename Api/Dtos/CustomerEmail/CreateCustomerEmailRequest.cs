using System;

namespace Api.Dtos.CustomerEmail;

public class CreateCustomerEmailRequest
{
    public string Email { get; init; } = default!;

    public bool Principal { get; init; }
}
