using System;

namespace Api.Dtos.PaymentMethod;

public sealed class PaymentMethodDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
