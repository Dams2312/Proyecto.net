using System;

namespace Api.Dtos.CustomerEmail;

public sealed class UpdateCustomerEmailRequest
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public string Email { get; init; } = default!;
    public bool Principal { get; init; }
}