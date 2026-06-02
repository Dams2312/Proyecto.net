using System;
using Api.Dtos.OrderServiceType;
using Application.UseCase.OrderServiceType;
using Domain.Entities.OrderServiceType;
using Mapster;

namespace Api.Mappings;

public sealed class OrderServiceTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderServiceType, OrderServiceTypeDto>()
            .Map(dest => dest.OrderId, src => src.OrderId.Value)
            .Map(dest => dest.ServiceTypeId, src => src.ServiceTypeId.Value);

        config.NewConfig<CreateOrderServiceTypeRequest, CreateOrderServiceType>()
            .MapWith(src => new CreateOrderServiceType(
                src.OrderId,
                src.ServiceTypeId
            ));

        config.NewConfig<UpdateOrderServiceTypeRequest, UpdateOrderServiceType>()
            .MapWith(src => new UpdateOrderServiceType(
                Guid.Empty,
                src.OrderId,
                src.ServiceTypeId
            ));
    }
}
