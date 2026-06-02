using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed class GetInventoryLogByIdHandler
    : IRequestHandler<GetInventoryLogById, InventoryLogEntity>
{
    private readonly IUnitOfWork _uow;

    public GetInventoryLogByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<InventoryLogEntity> Handle(
        GetInventoryLogById request,
        CancellationToken ct)
    {
        var entity = await _uow.InventoryLogs.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InventoryLogEntity no encontrado.");

        return entity;
    }
}

