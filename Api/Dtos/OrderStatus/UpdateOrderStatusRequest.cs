namespace Api.Dtos.OrderStatus;

public sealed class UpdateOrderStatusRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
