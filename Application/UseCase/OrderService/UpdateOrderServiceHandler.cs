using Domain.ValueObject.OrderService;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class UpdateOrderServiceHandler
    : IRequestHandler<UpdateOrderService, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderServiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderService request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceEntity no encontrado.");

        entity.UpdateVehicleId(OrderServiceVehicleId.Create(request.VehicleId));
        entity.UpdateReceptionistId(OrderServiceReceptionistId.Create(request.ReceptionistId));
        entity.UpdateStatusId(OrderServiceStatusId.Create(request.StatusId));
        entity.UpdateKilometrajeIngreso(OrderServiceKilometrajeIngreso.Create(request.KilometrajeIngreso));
        entity.UpdateFechaIngreso(OrderServiceFechaIngreso.Create(request.FechaIngreso));
        entity.UpdateFechaEstimada(OrderServiceFechaEstimada.Create(request.FechaEstimada));
        entity.UpdateFechaEntregaReal(OrderServiceFechaEntregaReal.Create(request.FechaEntregaReal));
        entity.UpdateAppointmentId(request.AppointmentId);
        entity.UpdateObservaciones(OrderServiceObservaciones.Create(request.Observaciones));

        await _uow.OrderServices.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

