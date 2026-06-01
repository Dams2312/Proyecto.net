using System;

namespace Api.Dtos.SpareCategory;

public sealed class SpareCategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
