using System;

namespace Api.Dtos.OrderServiceType;

public sealed class OrderServiceTypeDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ServiceTypeId { get; init; }
    public string ServiceTypeName { get; init; } = default!;
}
