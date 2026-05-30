using System;

namespace Api.Dtos.OrderNote;

public sealed class UpdateOrderNoteRequest
{
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public DateTime FechaNota { get; init; }
    public string Content { get; init; } = default!;
}
