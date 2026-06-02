using System;
using Api.Dtos.OrderStatus;
using Application.UseCase.OrderStatus;
using Domain.Entities.OrderStatus;
using Mapster;

namespace Api.Mappings;

public sealed class OrderStatusMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderStatus, OrderStatusDto>()
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Description, src => src.Description.Value);

        config.NewConfig<CreateOrderStatusRequest, CreateOrderStatus>()
            .MapWith(src => new CreateOrderStatus(
                src.Name,
                src.Description
            ));

        config.NewConfig<UpdateOrderStatusRequest, UpdateOrderStatus>()
            .MapWith(src => new UpdateOrderStatus(
                Guid.Empty,
                src.Name,
                src.Description
            ));
    }
}
