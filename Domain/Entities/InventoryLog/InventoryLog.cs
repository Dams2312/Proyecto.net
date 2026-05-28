using System;
using Domain.common;
using Domain.ValueObject.InventoryLog;

namespace Domain.Entities.InventoryLog;

public sealed class InventoryLog : BaseEntity<Guid>
{
    public InventoryLogSparePartId SparePartId { get; private set; }
    public InventoryLogQuantity Quantity { get; private set; }
    public InventoryLogStockResultante StockResultante { get; private set; }
    public InventoryLogTypeMovement TypeMovement { get; private set; }
    public InventoryLogUserId UserId { get; private set; }
    public InventoryLogFecha Fecha { get; private set; }
    public InventoryLogOrderId OrderId { get; private set; }
    public InventoryLogPurchaseId PurchaseId { get; private set; }
    public InventoryLogMotivo Motivo { get; private set; }

    private InventoryLog() { }

    public InventoryLog(
        InventoryLogSparePartId sparePartId,
        InventoryLogQuantity quantity,
        InventoryLogStockResultante stockResultante,
        InventoryLogTypeMovement typeMovement,
        InventoryLogUserId userId,
        InventoryLogFecha fecha,
        InventoryLogOrderId orderId,
        InventoryLogPurchaseId purchaseId,
        InventoryLogMotivo motivo)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
        StockResultante = stockResultante ?? throw new ArgumentNullException(nameof(stockResultante));
        TypeMovement = typeMovement ?? throw new ArgumentNullException(nameof(typeMovement));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        PurchaseId = purchaseId ?? throw new ArgumentNullException(nameof(purchaseId));
        Motivo = motivo ?? throw new ArgumentNullException(nameof(motivo));

        ValidateMovementConsistency(quantity, typeMovement);
    }

    public void UpdateSparePartId(InventoryLogSparePartId sparePartId)
    {
        SparePartId = sparePartId ?? throw new ArgumentNullException(nameof(sparePartId));
    }

    public void UpdateQuantity(InventoryLogQuantity quantity)
    {
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
        ValidateMovementConsistency(quantity, TypeMovement);
    }

    public void UpdateStockResultante(InventoryLogStockResultante stockResultante)
    {
        StockResultante = stockResultante ?? throw new ArgumentNullException(nameof(stockResultante));
    }

    public void UpdateTypeMovement(InventoryLogTypeMovement typeMovement)
    {
        TypeMovement = typeMovement ?? throw new ArgumentNullException(nameof(typeMovement));
        ValidateMovementConsistency(Quantity, typeMovement);
    }

    public void UpdateUserId(InventoryLogUserId userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public void UpdateFecha(InventoryLogFecha fecha)
    {
        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
    }

    public void UpdateOrderId(InventoryLogOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdatePurchaseId(InventoryLogPurchaseId purchaseId)
    {
        PurchaseId = purchaseId ?? throw new ArgumentNullException(nameof(purchaseId));
    }

    public void UpdateMotivo(InventoryLogMotivo motivo)
    {
        Motivo = motivo ?? throw new ArgumentNullException(nameof(motivo));
    }

    private static void ValidateMovementConsistency(InventoryLogQuantity quantity, InventoryLogTypeMovement typeMovement)
    {
        if (quantity is null)
            throw new ArgumentNullException(nameof(quantity));
        if (typeMovement is null)
            throw new ArgumentNullException(nameof(typeMovement));

        if (typeMovement.Value == "entrada" && quantity.Value < 0)
            throw new ArgumentException("Para movimientos de entrada la cantidad debe ser positiva.", nameof(quantity));

        if (typeMovement.Value == "salida" && quantity.Value > 0)
            throw new ArgumentException("Para movimientos de salida la cantidad debe ser negativa.", nameof(quantity));
    }
}
