using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed record CreateInventoryLog(
    int SparePartId,
    int Quantity,
    int StockResultante,
    string TypeMovement,
    int UserId,
    DateTime Fecha,
    int? OrderId,
    int? PurchaseId,
    string Motivo
) : IRequest<Guid>;
