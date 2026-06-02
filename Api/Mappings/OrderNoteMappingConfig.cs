using System;
using Api.Dtos.OrderNote;
using Application.UseCase.OrderNote;
using Domain.Entities.OrderNote;
using Mapster;

namespace Api.Mappings;

public sealed class OrderNoteMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderNote, OrderNoteDto>()
            .Map(dest => dest.OrderId, src => src.OrderId)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.FechaNota, src => src.FechaNota.Value)
            .Map(dest => dest.Content, src => src.Content.Value);

        config.NewConfig<CreateOrderNoteRequest, CreateOrderNote>()
            .MapWith(src => new CreateOrderNote(
                src.OrderId,
                src.UserId,
                src.Content,
                src.FechaNota
            ));

        config.NewConfig<UpdateOrderNoteRequest, UpdateOrderNote>()
            .MapWith(src => new UpdateOrderNote(
                Guid.Empty,
                src.OrderId,
                src.UserId,
                src.FechaNota,
                src.Content
            ));
    }
}
