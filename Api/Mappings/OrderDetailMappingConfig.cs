using System;
using Api.Dtos.OrderDetail;
using Application.UseCase.OrderDetail;
using Domain.Entities.OrderDetail;
using Mapster;

namespace Api.Mappings;

public sealed class OrderDetailMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderDetail, OrderDetailDto>()
            .Map(dest => dest.OrderId, src => src.OrderId)
            .Map(dest => dest.SparePartId, src => src.SparePartId)
            .Map(dest => dest.Quantity, src => src.Quantity.Value)
            .Map(dest => dest.PriceSnapshot, src => src.PriceSnapshot.Value);

        config.NewConfig<CreateOrderDetailRequest, CreateOrderDetail>()
            .MapWith(src => new CreateOrderDetail(
                src.OrderId,
                src.SparePartId,
                src.Quantity,
                src.PriceSnapshot
            ));

        config.NewConfig<UpdateOrderDetailRequest, UpdateOrderDetail>()
            .MapWith(src => new UpdateOrderDetail(
                Guid.Empty,
                src.OrderId,
                src.SparePartId,
                src.Quantity,
                src.PriceSnapshot
            ));
    }
}
