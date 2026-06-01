using System;

namespace Api.Dtos.Invoice;

public sealed class InvoiceDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid StatusId { get; init; }
    public string StatusName { get; init; } = default!;
    public Guid UserId { get; init; }
    public string UserName { get; init; } = default!;
    public decimal PartsCost { get; init; }
    public decimal LaborCost { get; init; }
    public decimal TaxPct { get; init; }
    public decimal Discount { get; init; }
    public decimal Total { get; init; }
}
