using System;
using Api.Dtos.OrderService;
using Application.UseCase.OrderService;
using Domain.Entities.OrderService;
using Mapster;

namespace Api.Mappings;

public sealed class OrderServiceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderService, OrderServiceDto>()
            .Map(dest => dest.VehicleId, src => src.VehicleId)
            .Map(dest => dest.ReceptionistId, src => src.ReceptionistId)
            .Map(dest => dest.StatusId, src => src.StatusId)
            .Map(dest => dest.KilometrajeIngreso, src => src.KilometrajeIngreso.Value)
            .Map(dest => dest.FechaIngreso, src => src.FechaIngreso.Value)
            .Map(dest => dest.FechaEstimada, src => src.FechaEstimada.Value)
            .Map(dest => dest.FechaEntregaReal, src => src.FechaEntregaReal.Value)
            .Map(dest => dest.AppointmentId, src => src.AppointmentId)
            .Map(dest => dest.Observaciones, src => src.Observaciones.Value);

        config.NewConfig<CreateOrderServiceRequest, CreateOrderService>()
            .MapWith(src => new CreateOrderService(
                src.VehicleId,
                src.ReceptionistId,
                src.StatusId,
                src.KilometrajeIngreso,
                src.FechaIngreso,
                src.FechaEstimada,
                src.FechaEntregaReal,
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
                src.FechaIngreso,
                src.FechaEstimada,
                src.FechaEntregaReal,
                src.AppointmentId,
                src.Observaciones
            ));
    }
}
