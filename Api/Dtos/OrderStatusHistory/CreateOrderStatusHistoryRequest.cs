using System;

namespace Api.Dtos.OrderStatusHistory;

public sealed class CreateOrderStatusHistoryRequest
{
    public Guid OrderId { get; init; }
    public Guid StatusId { get; init; }
    public Guid UserId { get; init; }
    public DateTime ChangeDate { get; init; }
}
