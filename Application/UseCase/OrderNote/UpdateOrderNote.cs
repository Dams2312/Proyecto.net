using System;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record UpdateOrderNote(
    Guid Id,
    Guid OrderId,
    Guid UserId,
    DateTime FechaNota,
    string Content
) : IRequest<Unit>;
