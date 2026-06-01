using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InventoryLog;
using Domain.ValueObject.InventoryLog;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed class UpdateInventoryLogHandler
    : IRequestHandler<UpdateInventoryLog, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateInventoryLogHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateInventoryLog request,
        CancellationToken ct)
    {
        var entity = await _uow.InventoryLogs.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InventoryLog no encontrado.");

        entity.UpdateSparePartId(request.SparePartId);
        entity.UpdateQuantity(InventoryLogQuantity.Create(request.Quantity));
        entity.UpdateStockResultante(InventoryLogStockResultante.Create(request.StockResultante));
        entity.UpdateTypeMovement(InventoryLogTypeMovement.Create(request.TypeMovement));
        entity.UpdateUserId(request.UserId);
        entity.UpdateFecha(InventoryLogFecha.Create(request.Fecha));
        entity.UpdateOrderId(request.OrderId);
        entity.UpdatePurchaseId(request.PurchaseId);
        entity.UpdateMotivo(InventoryLogMotivo.Create(request.Motivo));

        await _uow.InventoryLogs.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
