using System;
using Api.Dtos.OrderService;
using Application.UseCase.OrderService;
using Mapster;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService; // <-- alias

namespace Api.Mappings;

public sealed class OrderServiceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderServiceEntity, OrderServiceDto>()  // <-- usa el alias
            .Map(dest => dest.VehicleId, src => src.VehicleId.Value)
            .Map(dest => dest.ReceptionistId, src => src.ReceptionistId.Value)
            .Map(dest => dest.StatusId, src => src.StatusId.Value)
            .Map(dest => dest.KilometrajeIngreso, src => src.KilometrajeIngreso.Value)
            .Map(dest => dest.FechaIngreso, src => src.FechaIngreso.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.FechaEstimada, src => src.FechaEstimada != null && src.FechaEstimada.Value.HasValue ? (DateTime?)src.FechaEstimada.Value.Value.ToDateTime(TimeOnly.MinValue) : null)
            .Map(dest => dest.FechaEntregaReal, src => src.FechaEntregaReal != null && src.FechaEntregaReal.Value.HasValue ? (DateTime?)src.FechaEntregaReal.Value.Value.ToDateTime(TimeOnly.MinValue) : null)
            .Map(dest => dest.AppointmentId, src => src.AppointmentId)
            .Map(dest => dest.Observaciones, src => src.Observaciones != null ? src.Observaciones.Value : null);

        config.NewConfig<CreateOrderServiceRequest, CreateOrderService>()
            .MapWith(src => new CreateOrderService(
                src.VehicleId,
                src.ReceptionistId,
                src.StatusId,
                src.KilometrajeIngreso,
                DateOnly.FromDateTime(src.FechaIngreso),
                src.FechaEstimada.HasValue ? DateOnly.FromDateTime(src.FechaEstimada.Value) : (DateOnly?)null,
                src.FechaEntregaReal.HasValue ? DateOnly.FromDateTime(src.FechaEntregaReal.Value) : (DateOnly?)null,
                src.AppointmentId,
                src.Observaciones
            ));

        config.NewConfig<UpdateOrderServiceRequest, UpdateOrderService>()
            .MapWith(src => new UpdateOrderService(
                Guid.Empty,
                src.VehicleId,
                src.ReceptionistId,
                src.StatusId,
                src.KilometrajeIngreso,
                DateOnly.FromDateTime(src.FechaIngreso),
                src.FechaEstimada.HasValue ? DateOnly.FromDateTime(src.FechaEstimada.Value) : (DateOnly?)null,
                src.FechaEntregaReal.HasValue ? DateOnly.FromDateTime(src.FechaEntregaReal.Value) : (DateOnly?)null,
                src.AppointmentId,
                src.Observaciones
            ));
    }
}
