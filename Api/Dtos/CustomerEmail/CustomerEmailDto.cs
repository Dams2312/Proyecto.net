namespace Api.Dtos.CustomerEmail;

public sealed class CustomerEmailDto
{
    public Guid Id { get; init; }
    public string Email { get; init; } = default!;
    public bool Principal { get; init; }
}
