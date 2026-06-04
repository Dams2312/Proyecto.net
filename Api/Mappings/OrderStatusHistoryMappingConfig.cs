using System;
using Api.Dtos.OrderStatusHistory;
using Application.UseCase.OrderStatusHistory;
using Domain.Entities.OrderStatusHistory;
using Mapster;

namespace Api.Mappings;

public sealed class OrderStatusHistoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderStatusHistory, OrderStatusHistoryDto>()
            .Map(dest => dest.OrderId, src => src.OrderId.Value)
            .Map(dest => dest.StatusId, src => src.StatusId.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.ChangeDate, src => src.FechaCambio.Value);

        config.NewConfig<CreateOrderStatusHistoryRequest, CreateOrderStatusHistory>()
            .MapWith(src => new CreateOrderStatusHistory(
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.ChangeDate
            ));

        config.NewConfig<UpdateOrderStatusHistoryRequest, UpdateOrderStatusHistory>()
            .MapWith(src => new UpdateOrderStatusHistory(
                Guid.Empty,
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.ChangeDate
            ));
    }
}
