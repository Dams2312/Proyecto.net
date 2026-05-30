namespace Api.Dtos.ServiceType;

public sealed class CreateServiceTypeRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public int EstimatedDays { get; init; }
}
