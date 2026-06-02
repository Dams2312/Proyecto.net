using Api.Dtos.Purchase;
using Application.UseCase.Purchase;
using Domain.Entities.Purchase;
using Mapster;

namespace Api.Mappings;

public sealed class PurchaseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Purchase -> PurchaseDto
        config.NewConfig<Purchase, PurchaseDto>()
            .Map(dest => dest.Date,
                src => src.Date.Value)
            .Map(dest => dest.SupplierId,
                src => src.SupplierId.Value)
            .Map(dest => dest.UserId,
                src => src.UserId.Value)
            .Map(dest => dest.Status,
                src => src.Status.Value)
            .Map(dest => dest.Observations,
                src => src.Observations.Value)
            .Map(dest => dest.Total,
                src => src.Total.Value);

        // CreatePurchaseRequest -> CreatePurchase
        config.NewConfig<CreatePurchaseRequest, CreatePurchase>()
            .MapWith(src => new CreatePurchase(
                src.Date,
                src.SupplierId,
                src.UserId,
                src.Status,
                src.Observations,
                src.Total
            ));

        // UpdatePurchaseRequest -> UpdatePurchase
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
