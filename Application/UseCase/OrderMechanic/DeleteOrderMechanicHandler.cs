using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.OrderMechanic;

public sealed class DeleteOrderMechanicHandler
    : IRequestHandler<DeleteOrderMechanic, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderMechanicHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderMechanic request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderMechanics.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderMechanic no encontrado.");

        await _uow.OrderMechanics.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
