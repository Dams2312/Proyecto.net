using System;
using Api.Dtos.Purchase;
using Application.UseCase.Purchase;
using Domain.Entities.Purchase;
using Mapster;

namespace Api.Mappings;

public sealed class PurchaseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Purchase, PurchaseDto>()
            .Map(dest => dest.Date, src => src.Date.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.SupplierId, src => src.SupplierId.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Status, src => src.Status.Value)
            .Map(dest => dest.Observations, src => src.Observations != null ? src.Observations.Value : null)
            .Map(dest => dest.Total, src => src.Total.Value);

        config.NewConfig<CreatePurchaseRequest, CreatePurchase>()
            .MapWith(src => new CreatePurchase(
                DateOnly.FromDateTime(src.Date),
                src.SupplierId,
                src.UserId,
                src.Status,
                src.Observations,
                src.Total
            ));

        config.NewConfig<UpdatePurchaseRequest, UpdatePurchase>()
            .MapWith(src => new UpdatePurchase(
                Guid.Empty,
                src.Date,
                src.SupplierId,
                src.UserId,
                src.Status,
                src.Observations,
                src.Total
            ));
    }
}
