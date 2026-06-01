using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderServiceType;
using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed class GetOrderServiceTypeByIdHandler
    : IRequestHandler<GetOrderServiceTypeById, OrderServiceType>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceTypeByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderServiceType> Handle(
        GetOrderServiceTypeById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServiceTypes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceType no encontrado.");

        return entity;
    }
}
