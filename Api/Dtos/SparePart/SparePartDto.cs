using System;

namespace Api.Dtos.SparePart;

public sealed class SparePartDto
{
    public Guid Id { get; init; }
    public string Code { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal UnitPrice { get; init; }
    public int StockActual { get; init; }
    public int StockMin { get; init; }
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; } = default!;
    public Guid UnitId { get; init; }
    public string UnitName { get; init; } = default!;
    public bool Active { get; init; }
}
