using System;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed record UpdateInventoryLog(
    Guid Id,
    Guid SparePartId,
    int Quantity,
    int StockResultante,
    string TypeMovement,
    Guid UserId,
    DateTime Fecha,
    Guid OrderId,
    Guid PurchaseId,
    string Motivo
) : IRequest<Unit>;

