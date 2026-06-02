using Domain.ValueObject.OrderService;
using Application.Abstractions;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class CreateOrderServiceHandler
    : IRequestHandler<CreateOrderService, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderServiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderService request,
        CancellationToken ct)
    {
        var vehicleId = OrderServiceVehicleId.Create(request.VehicleId);

        var receptionistId = OrderServiceReceptionistId.Create(request.ReceptionistId);

        var statusId = OrderServiceStatusId.Create(request.StatusId);

        var kilometrajeIngreso = OrderServiceKilometrajeIngreso.Create(request.KilometrajeIngreso);

        var fechaIngreso = OrderServiceFechaIngreso.Create(request.FechaIngreso);

        var fechaEstimada = request.FechaEstimada.HasValue
            ? OrderServiceFechaEstimada.Create(request.FechaEstimada.Value)
            : null;

        var fechaEntregaReal = request.FechaEntregaReal.HasValue
            ? OrderServiceFechaEntregaReal.Create(request.FechaEntregaReal.Value)
            : null;

        var appointmentId = request.AppointmentId;

        var observaciones = OrderServiceObservaciones.Create(request.Observaciones);

        var orderService = new OrderServiceEntity(
            vehicleId,
            receptionistId,
            statusId,
            kilometrajeIngreso,
            fechaIngreso,
            fechaEstimada,
            fechaEntregaReal,
            appointmentId,
            observaciones);

        await _uow.OrderServices.AddAsync(orderService, ct);

        await _uow.SaveChangesAsync(ct);

        return orderService.Id;
    }
}
