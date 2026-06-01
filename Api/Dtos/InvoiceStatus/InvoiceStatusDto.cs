using System;

namespace Api.Dtos.InvoiceStatus;

public sealed class InvoiceStatusDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
}
