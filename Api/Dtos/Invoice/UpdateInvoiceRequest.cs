using System;

namespace Api.Dtos.Invoice;

public sealed class UpdateInvoiceRequest
{
    public Guid OrderId { get; init; }
    public Guid StatusId { get; init; }
    public Guid UserId { get; init; }
    public decimal PartsCost { get; init; }
    public decimal LaborCost { get; init; }
    public decimal TaxPct { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }
}
