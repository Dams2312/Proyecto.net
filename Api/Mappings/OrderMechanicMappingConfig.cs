using System;
using Api.Dtos.OrderMechanic;
using Application.UseCase.OrderMechanic;
using Domain.Entities.OrderMechanic;
using Mapster;

namespace Api.Mappings;

public sealed class OrderMechanicMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderMechanic, OrderMechanicDto>()
            .Map(dest => dest.OrderId, src => src.OrderId.Value)
            .Map(dest => dest.MechanicId, src => src.MechanicId.Value)
            .Map(dest => dest.FechaAsignacion, src => src.FechaAsignacion.Value.ToDateTime(TimeOnly.MinValue))
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.MechanicName);

        config.NewConfig<CreateOrderMechanicRequest, CreateOrderMechanic>()
            .MapWith(src => new CreateOrderMechanic(
                src.OrderId,
                src.MechanicId,
                DateOnly.FromDateTime(src.FechaAsignacion)
            ));

        config.NewConfig<UpdateOrderMechanicRequest, UpdateOrderMechanic>()
            .MapWith(src => new UpdateOrderMechanic(
                Guid.Empty,
                src.OrderId,
                src.MechanicId,
                src.FechaAsignacion
            ));
    }
}
