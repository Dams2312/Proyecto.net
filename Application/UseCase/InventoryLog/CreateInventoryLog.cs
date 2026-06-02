using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed record CreateInventoryLog(
    Guid SparePartId,
    int Quantity,
    int StockResultante,
    string TypeMovement,
    Guid UserId,
    DateTime Fecha,
    Guid OrderId,
    Guid PurchaseId,
    string Motivo
) : IRequest<Guid>;

