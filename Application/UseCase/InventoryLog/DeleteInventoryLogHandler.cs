using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed class DeleteInventoryLogHandler
    : IRequestHandler<DeleteInventoryLog, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteInventoryLogHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteInventoryLog request,
        CancellationToken ct)
    {
        var entity = await _uow.InventoryLogs.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InventoryLogEntity no encontrado.");

        await _uow.InventoryLogs.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

