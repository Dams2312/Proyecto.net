namespace Api.Dtos.ServiceType;

public sealed class ServiceTypeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int EstimatedDays { get; init; }
}
