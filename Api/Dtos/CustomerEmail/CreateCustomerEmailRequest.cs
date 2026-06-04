using System;

namespace Api.Dtos.CustomerEmail;

public class CreateCustomerEmailRequest
{
    public Guid CustomerId { get; init; }
    public string Email { get; init; } = default!;
    public bool Principal { get; init; }
}