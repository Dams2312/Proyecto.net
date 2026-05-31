using System;
using Domain.common;
using Domain.ValueObject.InventoryLog;

namespace Domain.Entities.InventoryLog;

public sealed class InventoryLog : BaseEntity<Guid>
{
    // FK COMO GUID
    public Guid SparePartId { get; private set; }

    public InventoryLogQuantity Quantity { get; private set; }

    public InventoryLogStockResultante StockResultante { get; private set; }

    public InventoryLogTypeMovement TypeMovement { get; private set; }

    // FK COMO GUID
    public Guid UserId { get; private set; }

    public InventoryLogFecha Fecha { get; private set; }

    // FK COMO GUID
    public Guid OrderId { get; private set; }

    // FK COMO GUID
    public Guid PurchaseId { get; private set; }

    public InventoryLogMotivo Motivo { get; private set; }

    private InventoryLog() { }

    public InventoryLog(
        Guid sparePartId,
        InventoryLogQuantity quantity,
        InventoryLogStockResultante stockResultante,
        InventoryLogTypeMovement typeMovement,
        Guid userId,
        InventoryLogFecha fecha,
        Guid orderId,
        Guid purchaseId,
        InventoryLogMotivo motivo)
    {
        if (sparePartId == Guid.Empty)
            throw new ArgumentException("El repuesto es obligatorio.", nameof(sparePartId));

        if (userId == Guid.Empty)
            throw new ArgumentException("El usuario es obligatorio.", nameof(userId));

        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));

        if (purchaseId == Guid.Empty)
            throw new ArgumentException("La compra es obligatoria.", nameof(purchaseId));

        SparePartId = sparePartId;

        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

        StockResultante = stockResultante ?? throw new ArgumentNullException(nameof(stockResultante));

        TypeMovement = typeMovement ?? throw new ArgumentNullException(nameof(typeMovement));

        UserId = userId;

        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));

        OrderId = orderId;

        PurchaseId = purchaseId;

        Motivo = motivo ?? throw new ArgumentNullException(nameof(motivo));

        ValidateMovementConsistency(quantity, typeMovement);
    }

    public void UpdateSparePartId(Guid sparePartId)
    {
        if (sparePartId == Guid.Empty)
            throw new ArgumentException("El repuesto es obligatorio.", nameof(sparePartId));

        SparePartId = sparePartId;
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

    public void UpdateUserId(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("El usuario es obligatorio.", nameof(userId));

        UserId = userId;
    }

    public void UpdateFecha(InventoryLogFecha fecha)
    {
        Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
    }

    public void UpdateOrderId(Guid orderId)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));

        OrderId = orderId;
    }

    public void UpdatePurchaseId(Guid purchaseId)
    {
        if (purchaseId == Guid.Empty)
            throw new ArgumentException("La compra es obligatoria.", nameof(purchaseId));

        PurchaseId = purchaseId;
    }

    public void UpdateMotivo(InventoryLogMotivo motivo)
    {
        Motivo = motivo ?? throw new ArgumentNullException(nameof(motivo));
    }

    private static void ValidateMovementConsistency(
        InventoryLogQuantity quantity,
        InventoryLogTypeMovement typeMovement)
    {
        if (quantity is null)
            throw new ArgumentNullException(nameof(quantity));

        if (typeMovement is null)
            throw new ArgumentNullException(nameof(typeMovement));

        if (typeMovement.Value == "entrada" && quantity.Value < 0)
            throw new ArgumentException(
                "Para movimientos de entrada la cantidad debe ser positiva.",
                nameof(quantity));

        if (typeMovement.Value == "salida" && quantity.Value > 0)
            throw new ArgumentException(
                "Para movimientos de salida la cantidad debe ser negativa.",
                nameof(quantity));
    }
}