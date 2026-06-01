using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InventoryLog;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed class GetInventoryLogByIdHandler
    : IRequestHandler<GetInventoryLogById, InventoryLog>
{
    private readonly IUnitOfWork _uow;

    public GetInventoryLogByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<InventoryLog> Handle(
        GetInventoryLogById request,
        CancellationToken ct)
    {
        var entity = await _uow.InventoryLogs.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InventoryLog no encontrado.");

        return entity;
    }
}
