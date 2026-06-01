using System;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record DeleteOrderNote(
    Guid Id
) : IRequest<Unit>;
