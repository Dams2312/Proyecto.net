using System;

namespace Api.Dtos.OrderServiceType;

public sealed class CreateOrderServiceTypeRequest
{
    public Guid OrderId { get; init; }
    public Guid ServiceTypeId { get; init; }
}
