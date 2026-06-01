using System;

namespace Api.Dtos.OrderStatus;

public sealed class OrderStatusDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
