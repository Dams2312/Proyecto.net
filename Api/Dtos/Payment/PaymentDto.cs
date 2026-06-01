using System;

namespace Api.Dtos.Payment;

public sealed class PaymentDto
{
    public Guid Id { get; init; }
    public Guid InvoiceId { get; init; }
    public Guid PaymentMethodId { get; init; }
    public string PaymentMethodName { get; init; } = default!;
    public DateTime PaymentDate { get; init; }
    public decimal Amount { get; init; }
    public string Reference { get; init; } = default!;
    public string Status { get; init; } = default!;
}
