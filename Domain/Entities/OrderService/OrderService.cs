using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.OrderService;

namespace Domain.Entities.OrderService;

public sealed class OrderService : BaseEntity<Guid>
{
    public OrderServiceVehicleId VehicleId { get; private set; }
    public OrderServiceReceptionistId ReceptionistId { get; private set; }
    public OrderServiceStatusId StatusId { get; private set; }
    public OrderServiceKilometrajeIngreso KilometrajeIngreso { get; private set; }
    public OrderServiceFechaIngreso FechaIngreso { get; private set; }
    public OrderServiceFechaEstimada? FechaEstimada { get; private set; }
    public OrderServiceFechaEntregaReal? FechaEntregaReal { get; private set; }
    public Guid? AppointmentId { get; private set; }
    public OrderServiceObservaciones? Observaciones { get; private set; }

    private OrderService() { }

    public OrderService(
        OrderServiceVehicleId vehicleId,
        OrderServiceReceptionistId receptionistId,
        OrderServiceStatusId statusId,
        OrderServiceKilometrajeIngreso kilometrajeIngreso,
        OrderServiceFechaIngreso fechaIngreso,
        OrderServiceFechaEstimada? fechaEstimada,
        OrderServiceFechaEntregaReal? fechaEntregaReal,
        Guid? appointmentId,
        OrderServiceObservaciones? observaciones)
    {
        ValidateDates(fechaIngreso, fechaEstimada, fechaEntregaReal);

        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
        ReceptionistId = receptionistId ?? throw new ArgumentNullException(nameof(receptionistId));
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
        KilometrajeIngreso = kilometrajeIngreso ?? throw new ArgumentNullException(nameof(kilometrajeIngreso));
        FechaIngreso = fechaIngreso ?? throw new ArgumentNullException(nameof(fechaIngreso));
        FechaEstimada = fechaEstimada;
        FechaEntregaReal = fechaEntregaReal;
        AppointmentId = appointmentId;
        Observaciones = observaciones;
    }

    private static void ValidateDates(
        OrderServiceFechaIngreso fechaIngreso,
        OrderServiceFechaEstimada? fechaEstimada,
        OrderServiceFechaEntregaReal? fechaEntregaReal)
    {
        if (fechaIngreso is null)
            throw new ArgumentNullException(nameof(fechaIngreso));

        if (fechaEstimada?.Value is not null && fechaEstimada.Value < fechaIngreso.Value)
            throw new ArgumentException("La fecha estimada no puede ser anterior a la fecha de ingreso.", nameof(fechaEstimada));

        if (fechaEntregaReal?.Value is not null && fechaEntregaReal.Value < fechaIngreso.Value)
            throw new ArgumentException("La fecha de entrega real no puede ser anterior a la fecha de ingreso.", nameof(fechaEntregaReal));

        if (fechaEstimada?.Value is not null && fechaEntregaReal?.Value is not null && fechaEntregaReal.Value < fechaEstimada.Value)
            throw new ArgumentException("La fecha de entrega real no puede ser anterior a la fecha estimada.", nameof(fechaEntregaReal));
    }

    public void UpdateVehicleId(OrderServiceVehicleId vehicleId)
    {
        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
    }

    public void UpdateReceptionistId(OrderServiceReceptionistId receptionistId)
    {
        ReceptionistId = receptionistId ?? throw new ArgumentNullException(nameof(receptionistId));
    }

    public void UpdateStatusId(OrderServiceStatusId statusId)
    {
        StatusId = statusId ?? throw new ArgumentNullException(nameof(statusId));
    }

    public void UpdateKilometrajeIngreso(OrderServiceKilometrajeIngreso kilometrajeIngreso)
    {
        KilometrajeIngreso = kilometrajeIngreso ?? throw new ArgumentNullException(nameof(kilometrajeIngreso));
    }

    public void UpdateFechaIngreso(OrderServiceFechaIngreso fechaIngreso)
    {
        if (fechaIngreso is null)
            throw new ArgumentNullException(nameof(fechaIngreso));

        ValidateDates(fechaIngreso, FechaEstimada, FechaEntregaReal);
        FechaIngreso = fechaIngreso;
    }

    public void UpdateFechaEstimada(OrderServiceFechaEstimada? fechaEstimada)
    {
        ValidateDates(FechaIngreso, fechaEstimada, FechaEntregaReal);
        FechaEstimada = fechaEstimada;
    }

    public void UpdateFechaEntregaReal(OrderServiceFechaEntregaReal? fechaEntregaReal)
    {
        ValidateDates(FechaIngreso, FechaEstimada, fechaEntregaReal);
        FechaEntregaReal = fechaEntregaReal;
    }

    public void UpdateAppointmentId(Guid? appointmentId)
    {
        AppointmentId = appointmentId;
    }

    public void UpdateObservaciones(OrderServiceObservaciones? observaciones)
    {
        Observaciones = observaciones;
    }
}
