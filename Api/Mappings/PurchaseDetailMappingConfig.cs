using Api.Dtos.PurchaseDetail;
using Application.UseCase.PurchaseDetail;
using Domain.Entities.PurchaseDetail;
using Mapster;

namespace Api.Mappings;

public sealed class PurchaseDetailMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // PurchaseDetail -> PurchaseDetailDto
        config.NewConfig<PurchaseDetail, PurchaseDetailDto>()
            .Map(dest => dest.PurchaseId,
                src => src.PurchaseId.Value)
            .Map(dest => dest.SparePartId,
                src => src.SparePartId.Value)
            .Map(dest => dest.Quantity,
                src => src.Quantity.Value)
            .Map(dest => dest.UnitPrice,
                src => src.UnitPrice.Value);

        // CreatePurchaseDetailRequest -> CreatePurchaseDetail
        config.NewConfig<CreatePurchaseDetailRequest, CreatePurchaseDetail>()
            .MapWith(src => new CreatePurchaseDetail(
                src.PurchaseId,
                src.SparePartId,
                src.Quantity,
                src.UnitPrice
            ));

        // UpdatePurchaseDetailRequest -> UpdatePurchaseDetail
        config.NewConfig<UpdatePurchaseDetailRequest, UpdatePurchaseDetail>()
            .MapWith(src => new UpdatePurchaseDetail(
                Guid.Empty,
                src.PurchaseId,
                src.SparePartId,
                src.Quantity,
                src.UnitPrice
            ));
    }
}
