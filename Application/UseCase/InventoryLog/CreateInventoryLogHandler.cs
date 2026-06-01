using Application.Abstractions;
using Domain.Entities.InventoryLog;
using Domain.ValueObject.InventoryLog;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCases.InventoryLog;

public sealed class CreateInventoryLogHandler
    : IRequestHandler<CreateInventoryLog, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateInventoryLogHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateInventoryLog request,
        CancellationToken ct)
    {
        var sparePartId = InventoryLogSparePartId.Create(request.SparePartId);

        var quantity = InventoryLogQuantity.Create(request.Quantity);

        var stockResultante = InventoryLogStockResultante.Create(request.StockResultante);

        var typeMovement = InventoryLogTypeMovement.Create(request.TypeMovement);

        var userId = InventoryLogUserId.Create(request.UserId);

        var fecha = InventoryLogFecha.Create(request.Fecha);

        var orderId = InventoryLogOrderId.Create(request.OrderId);

        var purchaseId = InventoryLogPurchaseId.Create(request.PurchaseId);

        var motivo = InventoryLogMotivo.Create(request.Motivo);

        var inventoryLog = new InventoryLogEntity(
            sparePartId,
            quantity,
            stockResultante,
            typeMovement,
            userId,
            fecha,
            orderId,
            purchaseId,
            motivo);

        await _uow.InventoryLogs.AddAsync(inventoryLog, ct);

        await _uow.SaveChangesAsync(ct);

        return inventoryLog.Id;
    }
}