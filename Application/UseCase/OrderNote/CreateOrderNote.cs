using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record CreateOrderNote(
    Guid OrderId,
    Guid UserId,
    string Content,
    DateTime FechaNota
) : IRequest<Guid>;