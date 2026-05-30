using System;

namespace Api.Dtos.OrderStatusHistory;

public sealed class OrderStatusHistoryDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid StatusId { get; init; }
    public string StatusName { get; init; } = default!;
    public Guid UserId { get; init; }
    public string UserName { get; init; } = default!;
    public DateTime ChangeDate { get; init; }
}
