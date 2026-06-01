using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderService;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed class GetOrderServiceByIdHandler
    : IRequestHandler<GetOrderServiceById, OrderService>
{
    private readonly IUnitOfWork _uow;

    public GetOrderServiceByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderService> Handle(
        GetOrderServiceById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderService no encontrado.");

        return entity;
    }
}
