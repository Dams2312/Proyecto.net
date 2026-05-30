namespace Api.Dtos.OrderStatus;

public sealed class CreateOrderStatusRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
