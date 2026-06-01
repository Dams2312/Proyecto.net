using MediatR;

namespace Application.UseCases.InventoryLog;

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
