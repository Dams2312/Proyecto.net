using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.MechanicTask;
using Domain.ValueObject.MechanicTask;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed class UpdateMechanicTaskHandler
    : IRequestHandler<UpdateMechanicTask, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateMechanicTaskHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateMechanicTask request,
        CancellationToken ct)
    {
        var entity = await _uow.MechanicTasks.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("MechanicTask no encontrado.");

        entity.UpdateOrderId(MechanicTaskOrderId.Create(request.OrderId));
        entity.UpdateMechanicId(MechanicTaskMechanicId.Create(request.MechanicId));
        entity.UpdateServiceTypeId(MechanicTaskServiceTypeId.Create(request.ServiceTypeId));
        entity.UpdateDescription(MechanicTaskDescription.Create(request.Description));
        entity.UpdateHourlyCost(MechanicTaskHourlyCost.Create(request.HourlyCost));
        entity.UpdateHoursWorked(MechanicTaskHoursWorked.Create(request.HoursWorked));
        entity.UpdateFechaInicio(MechanicTaskFechaInicio.Create(request.FechaInicio));
        entity.UpdateFechaFin(MechanicTaskFechaFin.Create(request.FechaFin));
        entity.UpdateStatus(MechanicTaskStatus.Create(request.Status));

        await _uow.MechanicTasks.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
