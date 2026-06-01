using System;
using Domain.Entities.OrderNote;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record GetOrderNoteById(
    Guid Id
) : IRequest<OrderNote>;
