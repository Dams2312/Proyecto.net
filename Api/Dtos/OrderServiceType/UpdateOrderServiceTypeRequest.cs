using System;

namespace Api.Dtos.OrderServiceType;

public sealed class UpdateOrderServiceTypeRequest
{
    public Guid OrderId { get; init; }
    public Guid ServiceTypeId { get; init; }
}
