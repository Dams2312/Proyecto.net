using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderNote;

namespace Domain.Entities.OrderNote;

public sealed class OrderNote : BaseEntity<Guid>
{
    public OrderNoteOrderId OrderId { get; private set; }
    public OrderNoteUserId UserId { get; private set; }
    public OrderNoteFechaNota FechaNota { get; private set; }
    public OrderNoteContent Content { get; private set; }

    private OrderNote() { }

    public OrderNote(
        OrderNoteOrderId orderId,
        OrderNoteUserId userId,
        OrderNoteFechaNota fechaNota,
        OrderNoteContent content)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        FechaNota = fechaNota ?? throw new ArgumentNullException(nameof(fechaNota));
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }

    public void UpdateOrderId(OrderNoteOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateUserId(OrderNoteUserId userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public void UpdateFechaNota(OrderNoteFechaNota fechaNota)
    {
        FechaNota = fechaNota ?? throw new ArgumentNullException(nameof(fechaNota));
    }

    public void UpdateContent(OrderNoteContent content)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }
}
