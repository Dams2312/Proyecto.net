using System;
using Domain.common;
using Domain.ValueObject.Warranty;

namespace Domain.Entities.Warranty;

public sealed class Warranty : BaseEntity<Guid>
{
    // FKs COMO GUID
    public Guid OrderId { get; private set; }
    public Guid ServiceTypeId { get; private set; }
    public Guid MechanicId { get; private set; }

    public WarrantyFechaInicio FechaInicio { get; private set; }
    public WarrantyFechaVencimiento FechaVencimiento { get; private set; }
    public WarrantyEstado Estado { get; private set; }
    public WarrantyCondiciones? Condiciones { get; private set; }

    private Warranty() { }

    public Warranty(
        Guid orderId,
        Guid serviceTypeId,
        Guid mechanicId,
        WarrantyFechaInicio fechaInicio,
        WarrantyFechaVencimiento fechaVencimiento,
        WarrantyEstado estado,
        WarrantyCondiciones? condiciones = null)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));

        if (serviceTypeId == Guid.Empty)
            throw new ArgumentException("El tipo de servicio es obligatorio.", nameof(serviceTypeId));

        if (mechanicId == Guid.Empty)
            throw new ArgumentException("El mecánico es obligatorio.", nameof(mechanicId));

        OrderId = orderId;
        ServiceTypeId = serviceTypeId;
        MechanicId = mechanicId;

        FechaInicio = fechaInicio ?? throw new ArgumentNullException(nameof(fechaInicio));
        FechaVencimiento = fechaVencimiento ?? throw new ArgumentNullException(nameof(fechaVencimiento));
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
        Condiciones = condiciones;

        ValidateDates(FechaInicio, FechaVencimiento);
    }

    public void UpdateOrderId(Guid orderId)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("La orden es obligatoria.", nameof(orderId));
        OrderId = orderId;
    }

    public void UpdateServiceTypeId(Guid serviceTypeId)
    {
        if (serviceTypeId == Guid.Empty)
            throw new ArgumentException("El tipo de servicio es obligatorio.", nameof(serviceTypeId));
        ServiceTypeId = serviceTypeId;
    }

    public void UpdateMechanicId(Guid mechanicId)
    {
        if (mechanicId == Guid.Empty)
            throw new ArgumentException("El mecánico es obligatorio.", nameof(mechanicId));
        MechanicId = mechanicId;
    }

    public void UpdateFechaInicio(WarrantyFechaInicio fechaInicio)
    {
        FechaInicio = fechaInicio ?? throw new ArgumentNullException(nameof(fechaInicio));
        ValidateDates(FechaInicio, FechaVencimiento);
    }

    public void UpdateFechaVencimiento(WarrantyFechaVencimiento fechaVencimiento)
    {
        FechaVencimiento = fechaVencimiento ?? throw new ArgumentNullException(nameof(fechaVencimiento));
        ValidateDates(FechaInicio, FechaVencimiento);
    }

    public void UpdateEstado(WarrantyEstado estado)
    {
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
    }

    public void UpdateCondiciones(WarrantyCondiciones? condiciones)
    {
        Condiciones = condiciones;
    }

    private static void ValidateDates(WarrantyFechaInicio fechaInicio, WarrantyFechaVencimiento fechaVencimiento)
    {
        if (fechaInicio is null)
            throw new ArgumentNullException(nameof(fechaInicio));

        if (fechaVencimiento is null)
            throw new ArgumentNullException(nameof(fechaVencimiento));

        if (fechaVencimiento.Value < fechaInicio.Value)
            throw new ArgumentException("La fecha de vencimiento no puede ser anterior a la fecha de inicio.", nameof(fechaVencimiento));
    }
}