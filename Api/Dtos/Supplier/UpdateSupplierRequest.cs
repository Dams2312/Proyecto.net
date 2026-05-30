using System;

namespace Api.Dtos.Supplier;

public sealed class UpdateSupplierRequest
{
    public string Name { get; init; } = default!;
    public string Nit { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public Guid CityId { get; init; }
    public bool Active { get; init; }
}
