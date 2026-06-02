using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class GetOrderServiceByIdHandler
    : IRequestHandler<GetOrderServiceById, OrderServiceEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderServiceEntity> Handle(
        GetOrderServiceById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceEntity no encontrado.");

        return entity;
    }
}

