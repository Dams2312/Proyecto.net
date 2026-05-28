using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.MechanicTask;

namespace Domain.Entities.MechanicTask;

public sealed class MechanicTask : BaseEntity<Guid>
{
    public MechanicTaskOrderId OrderId { get; private set; }
    public MechanicTaskMechanicId MechanicId { get; private set; }
    public MechanicTaskServiceTypeId ServiceTypeId { get; private set; }
    public MechanicTaskDescription Description { get; private set; }
    public MechanicTaskStatus Status { get; private set; }
    public MechanicTaskFechaInicio FechaInicio { get; private set; }
    public MechanicTaskFechaFin FechaFin { get; private set; }
    public MechanicTaskHoursWorked HoursWorked { get; private set; }
    public MechanicTaskHourlyCost HourlyCost { get; private set; }

    private MechanicTask() { }

    public MechanicTask(
        MechanicTaskOrderId orderId,
        MechanicTaskMechanicId mechanicId,
        MechanicTaskServiceTypeId serviceTypeId,
        MechanicTaskDescription description,
        MechanicTaskStatus status,
        MechanicTaskFechaInicio fechaInicio,
        MechanicTaskFechaFin fechaFin,
        MechanicTaskHoursWorked hoursWorked,
        MechanicTaskHourlyCost hourlyCost)
    {
        if (fechaFin.Value.HasValue && fechaInicio.Value.HasValue && fechaFin.Value.Value < fechaInicio.Value.Value)
            throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.", nameof(fechaFin));

        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        MechanicId = mechanicId ?? throw new ArgumentNullException(nameof(mechanicId));
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        FechaInicio = fechaInicio ?? throw new ArgumentNullException(nameof(fechaInicio));
        FechaFin = fechaFin ?? throw new ArgumentNullException(nameof(fechaFin));
        HoursWorked = hoursWorked ?? throw new ArgumentNullException(nameof(hoursWorked));
        HourlyCost = hourlyCost ?? throw new ArgumentNullException(nameof(hourlyCost));
    }

    public void UpdateOrderId(MechanicTaskOrderId orderId)
    {
        OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
    }

    public void UpdateMechanicId(MechanicTaskMechanicId mechanicId)
    {
        MechanicId = mechanicId ?? throw new ArgumentNullException(nameof(mechanicId));
    }

    public void UpdateServiceTypeId(MechanicTaskServiceTypeId serviceTypeId)
    {
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
    }

    public void UpdateDescription(MechanicTaskDescription description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void UpdateStatus(MechanicTaskStatus status)
    {
        Status = status ?? throw new ArgumentNullException(nameof(status));
    }

    public void UpdateFechaInicio(MechanicTaskFechaInicio fechaInicio)
    {
        if (fechaInicio is null)
            throw new ArgumentNullException(nameof(fechaInicio));

        if (FechaFin.Value.HasValue && fechaInicio.Value.HasValue && FechaFin.Value.Value < fechaInicio.Value.Value)
            throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.", nameof(fechaInicio));

        FechaInicio = fechaInicio;
    }

    public void UpdateFechaFin(MechanicTaskFechaFin fechaFin)
    {
        if (fechaFin is null)
            throw new ArgumentNullException(nameof(fechaFin));

        if (FechaInicio.Value.HasValue && fechaFin.Value.HasValue && fechaFin.Value.Value < FechaInicio.Value.Value)
            throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.", nameof(fechaFin));

        FechaFin = fechaFin;
    }

    public void UpdateHoursWorked(MechanicTaskHoursWorked hoursWorked)
    {
        HoursWorked = hoursWorked ?? throw new ArgumentNullException(nameof(hoursWorked));
    }

    public void UpdateHourlyCost(MechanicTaskHourlyCost hourlyCost)
    {
        HourlyCost = hourlyCost ?? throw new ArgumentNullException(nameof(hourlyCost));
    }
}
