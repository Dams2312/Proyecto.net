using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Appointment;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed class GetAppoinmentsPagedHandler
    : IRequestHandler<GetAppoinmentsPaged, IReadOnlyList<Appointment>>
{
    private readonly IUnitOfWork _uow;

    public GetAppoinmentsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Appointment>> Handle(
        GetAppoinmentsPaged request,
        CancellationToken ct)
    {
        return await _uow.Appointments.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

