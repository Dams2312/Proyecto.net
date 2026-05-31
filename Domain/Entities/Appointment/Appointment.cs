using System;
using Domain.common;
using Domain.ValueObject.Appointment;

namespace Domain.Entities.Appointment;

public sealed class Appointment : BaseEntity<Guid>
{
    // FK COMO GUID
    public Guid VehicleId { get; private set; }

    public Guid ServiceTypeId { get; private set; }

    public Guid ReceptionistId { get; private set; }

    public AppointmentDate Date { get; private set; }

    public AppointmentStartTime StartTime { get; private set; }

    public AppointmentEndTime EndTime { get; private set; }

    public AppointmentStatus Status { get; private set; }

    public AppointmentObservations Observations { get; private set; }

    private Appointment() { }

    public Appointment(
        Guid vehicleId,
        Guid serviceTypeId,
        Guid receptionistId,
        AppointmentDate date,
        AppointmentStartTime startTime,
        AppointmentEndTime endTime,
        AppointmentStatus status,
        AppointmentObservations observations)
    {
        if (vehicleId == Guid.Empty)
            throw new ArgumentException("El vehículo es obligatorio.", nameof(vehicleId));

        if (serviceTypeId == Guid.Empty)
            throw new ArgumentException("El tipo de servicio es obligatorio.", nameof(serviceTypeId));

        if (receptionistId == Guid.Empty)
            throw new ArgumentException("El recepcionista es obligatorio.", nameof(receptionistId));

        if (endTime.Value < startTime.Value)
            throw new ArgumentException("La hora de fin no puede ser anterior a la hora de inicio.");

        VehicleId = vehicleId;
        ServiceTypeId = serviceTypeId;
        ReceptionistId = receptionistId;

        Date = date ?? throw new ArgumentNullException(nameof(date));
        StartTime = startTime ?? throw new ArgumentNullException(nameof(startTime));
        EndTime = endTime ?? throw new ArgumentNullException(nameof(endTime));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        Observations = observations ?? throw new ArgumentNullException(nameof(observations));
    }

    public void UpdateVehicleId(Guid vehicleId)
    {
        if (vehicleId == Guid.Empty)
            throw new ArgumentException("El vehículo es obligatorio.", nameof(vehicleId));

        VehicleId = vehicleId;
    }

    public void UpdateServiceTypeId(Guid serviceTypeId)
    {
        if (serviceTypeId == Guid.Empty)
            throw new ArgumentException("El tipo de servicio es obligatorio.", nameof(serviceTypeId));

        ServiceTypeId = serviceTypeId;
    }

    public void UpdateReceptionistId(Guid receptionistId)
    {
        if (receptionistId == Guid.Empty)
            throw new ArgumentException("El recepcionista es obligatorio.", nameof(receptionistId));

        ReceptionistId = receptionistId;
    }

    public void UpdateDate(AppointmentDate date)
    {
        Date = date ?? throw new ArgumentNullException(nameof(date));
    }

    public void UpdateStartTime(AppointmentStartTime startTime)
    {
        if (startTime is null)
            throw new ArgumentNullException(nameof(startTime));

        if (EndTime.Value < startTime.Value)
            throw new ArgumentException("La hora de inicio no puede ser posterior a la hora de fin.", nameof(startTime));

        StartTime = startTime;
    }

    public void UpdateEndTime(AppointmentEndTime endTime)
    {
        if (endTime is null)
            throw new ArgumentNullException(nameof(endTime));

        if (endTime.Value < StartTime.Value)
            throw new ArgumentException("La hora de fin no puede ser anterior a la hora de inicio.", nameof(endTime));

        EndTime = endTime;
    }

    public void UpdateStatus(AppointmentStatus status)
    {
        Status = status ?? throw new ArgumentNullException(nameof(status));
    }

    public void UpdateObservations(AppointmentObservations observations)
    {
        Observations = observations ?? throw new ArgumentNullException(nameof(observations));
    }
}