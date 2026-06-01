namespace Api.Dtos.SpareCategory;

public sealed class CreateSpareCategoryRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
}
