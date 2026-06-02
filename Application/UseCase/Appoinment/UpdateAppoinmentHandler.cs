using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Appointment;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed class UpdateAppoinmentHandler
    : IRequestHandler<UpdateAppoinment, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateAppoinmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateAppoinment request,
        CancellationToken ct)
    {
        var appointment = await _uow.Appointments.GetByIdAsync(request.Id, ct);

        if (appointment is null)
            throw new KeyNotFoundException("Cita no encontrada.");

        appointment.UpdateVehicleId(request.VehicleId);
        appointment.UpdateServiceTypeId(request.ServiceTypeId);
        appointment.UpdateReceptionistId(request.ReceptionistId);
        appointment.UpdateDate(AppointmentDate.Create(request.Date));
        appointment.UpdateStartTime(AppointmentStartTime.Create(request.StartTime));
        appointment.UpdateEndTime(AppointmentEndTime.Create(request.EndTime));
        appointment.UpdateStatus(AppointmentStatus.Create(request.Status));
        appointment.UpdateObservations(AppointmentObservations.Create(request.Observations));

        await _uow.Appointments.UpdateAsync(appointment, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

