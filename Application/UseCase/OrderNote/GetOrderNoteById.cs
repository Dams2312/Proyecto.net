using System;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed record GetOrderNoteById(
    Guid Id
) : IRequest<OrderNoteEntity>;

