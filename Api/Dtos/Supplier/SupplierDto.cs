using System;

namespace Api.Dtos.Supplier;

public sealed class SupplierDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Nit { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public Guid CityId { get; init; }
    public string CityName { get; init; } = default!;
    public bool Active { get; init; }
}
