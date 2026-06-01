using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record CreateOrderNote(
    int OrderId,
    int UserId,
    string Content,
    DateTime FechaNota
) : IRequest<Guid>;