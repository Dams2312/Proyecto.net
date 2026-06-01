using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderServiceType;
using Domain.ValueObject.OrderServiceType;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed class UpdateOrderServiceTypeHandler
    : IRequestHandler<UpdateOrderServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderServiceType request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServiceTypes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceType no encontrado.");

        entity.UpdateOrderId(OrderServiceTypeOrderId.Create(request.OrderId));
        entity.UpdateServiceTypeId(OrderServiceTypeServiceTypeId.Create(request.ServiceTypeId));

        await _uow.OrderServiceTypes.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
