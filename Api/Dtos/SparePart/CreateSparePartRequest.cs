using System;

namespace Api.Dtos.SparePart;

public sealed class CreateSparePartRequest
{
    public string Code { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal UnitPrice { get; init; }
    public int StockActual { get; init; }
    public int StockMin { get; init; }
    public Guid CategoryId { get; init; }
    public Guid UnitId { get; init; }
    public bool Active { get; init; }
}
