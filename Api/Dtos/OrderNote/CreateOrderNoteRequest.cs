using System;

namespace Api.Dtos.OrderNote;

public sealed class CreateOrderNoteRequest
{
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public DateTime FechaNota { get; init; }
    public string Content { get; init; } = default!;
}
