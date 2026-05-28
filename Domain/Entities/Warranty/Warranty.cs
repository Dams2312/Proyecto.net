using System;
using Domain.common;
using Domain.ValueObject.Warranty;

namespace Domain.Entities.Warranty;

public sealed class Warranty : BaseEntity<Guid>
{
    public WarrantyFechaInicio FechaInicio { get; private set; }
    public WarrantyFechaVencimiento FechaVencimiento { get; private set; }
    public WarrantyEstado Estado { get; private set; }
    public WarrantyCondiciones Condiciones { get; private set; }

    private Warranty() { }

    public Warranty(
        WarrantyFechaInicio fechaInicio,
        WarrantyFechaVencimiento fechaVencimiento,
        WarrantyEstado estado,
        WarrantyCondiciones condiciones)
    {
        FechaInicio = fechaInicio ?? throw new ArgumentNullException(nameof(fechaInicio));
        FechaVencimiento = fechaVencimiento ?? throw new ArgumentNullException(nameof(fechaVencimiento));
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
        Condiciones = condiciones ?? throw new ArgumentNullException(nameof(condiciones));

        ValidateDates(FechaInicio, FechaVencimiento);
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

    public void UpdateCondiciones(WarrantyCondiciones condiciones)
    {
        Condiciones = condiciones ?? throw new ArgumentNullException(nameof(condiciones));
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
