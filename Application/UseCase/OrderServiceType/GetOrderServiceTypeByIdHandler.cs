using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed class GetOrderServiceTypeByIdHandler
    : IRequestHandler<GetOrderServiceTypeById, OrderServiceTypeEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceTypeByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderServiceTypeEntity> Handle(
        GetOrderServiceTypeById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServiceTypes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceTypeEntity no encontrado.");

        return entity;
    }
}

