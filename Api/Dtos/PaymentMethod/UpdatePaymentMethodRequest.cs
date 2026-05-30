namespace Api.Dtos.PaymentMethod;

public sealed class UpdatePaymentMethodRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
