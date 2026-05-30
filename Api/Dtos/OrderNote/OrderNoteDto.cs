using System;

namespace Api.Dtos.OrderNote;

public sealed class OrderNoteDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public string UserName { get; init; } = default!;
    public DateTime FechaNota { get; init; }
    public string Content { get; init; } = default!;
}
