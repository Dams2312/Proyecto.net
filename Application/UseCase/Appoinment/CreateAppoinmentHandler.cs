using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Appointment;
using Domain.ValueObject.Appointment;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed class CreateAppoinmentHandler
    : IRequestHandler<CreateAppoinment, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateAppoinmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateAppoinment request,
        CancellationToken ct)
    {
        var vehicleId = request.VehicleId;
        var serviceTypeId = request.ServiceTypeId;
        var receptionistId = request.ReceptionistId;
        var date = AppointmentDate.Create(request.Date);
        var startTime = AppointmentStartTime.Create(request.StartTime);
        var endTime = AppointmentEndTime.Create(request.EndTime);
        var status = AppointmentStatus.Create(request.Status);
        var observations = AppointmentObservations.Create(request.Observations);

        var appointment = new Appointment(
            vehicleId,
            serviceTypeId,
            receptionistId,
            date,
            startTime,
            endTime,
            status,
            observations);

        await _uow.Appointments.AddAsync(appointment, ct);
        await _uow.SaveChangesAsync(ct);

        return appointment.Id;
    }
}
