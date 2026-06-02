using Domain.ValueObject.MechanicTask;
using Application.Abstractions;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed class CreateMechanicTaskHandler
    : IRequestHandler<CreateMechanicTask, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateMechanicTaskHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateMechanicTask request,
        CancellationToken ct)
    {
        var orderId = MechanicTaskOrderId.Create(request.OrderId);

        var mechanicId = MechanicTaskMechanicId.Create(request.MechanicId);

        var serviceTypeId = MechanicTaskServiceTypeId.Create(request.ServiceTypeId);

        var description = MechanicTaskDescription.Create(request.Description);

        var hourlyCost = MechanicTaskHourlyCost.Create(request.HourlyCost);

        var hoursWorked = MechanicTaskHoursWorked.Create(request.HoursWorked);

        var fechaInicio = MechanicTaskFechaInicio.Create(request.FechaInicio);

        var fechaFin = MechanicTaskFechaFin.Create(request.FechaFin);

        var status = MechanicTaskStatus.Create(request.Status);

        var mechanicTask = new MechanicTaskEntity(
            orderId,
            mechanicId,
            serviceTypeId,
            description,
            status,
            fechaInicio,
            fechaFin,
            hoursWorked,
            hourlyCost);

        await _uow.MechanicTasks.AddAsync(mechanicTask, ct);

        await _uow.SaveChangesAsync(ct);

        return mechanicTask.Id;
    }
}
