using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Appointment;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed class GetAppoinmentByIdHandler
    : IRequestHandler<GetAppoinmentById, Appointment>
{
    private readonly IUnitOfWork _uow;

    public GetAppoinmentByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Appointment> Handle(
        GetAppoinmentById request,
        CancellationToken ct)
    {
        var appointment = await _uow.Appointments.GetByIdAsync(request.Id, ct);

        if (appointment is null)
            throw new KeyNotFoundException("Cita no encontrada.");

        return appointment;
    }
}

