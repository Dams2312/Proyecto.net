namespace Api.Dtos.SpareCategory;

public sealed class UpdateSpareCategoryRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
