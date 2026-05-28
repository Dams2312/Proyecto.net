using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Appointment;

namespace Domain.Entities.Appointment;

public sealed class Appointment : BaseEntity<Guid>
{
    public AppointmentVehicleId VehicleId { get; private set; }
    public AppointmentServiceTypeId ServiceTypeId { get; private set; }
    public AppointmentReceptionistId ReceptionistId { get; private set; }
    public AppointmentDate Date { get; private set; }
    public AppointmentStartTime StartTime { get; private set; }
    public AppointmentEndTime EndTime { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public AppointmentObservations Observations { get; private set; }

    private Appointment() { }

    public Appointment(
        AppointmentVehicleId vehicleId,
        AppointmentServiceTypeId serviceTypeId,
        AppointmentReceptionistId receptionistId,
        AppointmentDate date,
        AppointmentStartTime startTime,
        AppointmentEndTime endTime,
        AppointmentStatus status,
        AppointmentObservations observations)
    {
        if (endTime.Value < startTime.Value)
            throw new ArgumentException("La hora de fin no puede ser anterior a la hora de inicio.");

        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
        ReceptionistId = receptionistId ?? throw new ArgumentNullException(nameof(receptionistId));
        Date = date ?? throw new ArgumentNullException(nameof(date));
        StartTime = startTime ?? throw new ArgumentNullException(nameof(startTime));
        EndTime = endTime ?? throw new ArgumentNullException(nameof(endTime));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        Observations = observations ?? throw new ArgumentNullException(nameof(observations));
    }

    public void UpdateVehicleId(AppointmentVehicleId vehicleId)
    {
        VehicleId = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));
    }

    public void UpdateServiceTypeId(AppointmentServiceTypeId serviceTypeId)
    {
        ServiceTypeId = serviceTypeId ?? throw new ArgumentNullException(nameof(serviceTypeId));
    }

    public void UpdateReceptionistId(AppointmentReceptionistId receptionistId)
    {
        ReceptionistId = receptionistId ?? throw new ArgumentNullException(nameof(receptionistId));
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
