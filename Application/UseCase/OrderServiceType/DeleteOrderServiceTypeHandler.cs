using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed class DeleteOrderServiceTypeHandler
    : IRequestHandler<DeleteOrderServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderServiceType request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServiceTypes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceTypeEntity no encontrado.");

        await _uow.OrderServiceTypes.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

