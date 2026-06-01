namespace Api.Dtos.PaymentMethod;

public sealed class CreatePaymentMethodRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
