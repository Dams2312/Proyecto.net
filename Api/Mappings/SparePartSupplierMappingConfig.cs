using Api.Dtos.SparePartSupplier;
using Application.UseCase.SparePartSupplier;
using Domain.Entities.SparePartSupplier;
using Mapster;

namespace Api.Mappings;

public sealed class SparePartSupplierMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // SparePartSupplier -> SparePartSupplierDto
        config.NewConfig<SparePartSupplier, SparePartSupplierDto>()
            .Map(dest => dest.SparePartId,
                src => src.SparePartId.Value)
            .Map(dest => dest.SupplierId,
                src => src.SupplierId.Value)
            .Map(dest => dest.PurchasePrice,
                src => src.PurchasePrice.Value)
            .Map(dest => dest.Principal,
                src => src.Principal.Value);

        // CreateSparePartSupplierRequest -> CreateSparePartSupplier
        config.NewConfig<CreateSparePartSupplierRequest, CreateSparePartSupplier>()
            .MapWith(src => new CreateSparePartSupplier(
                src.SparePartId,
                src.SupplierId,
                src.PurchasePrice,
                src.Principal
            ));

        // UpdateSparePartSupplierRequest -> UpdateSparePartSupplier
        config.NewConfig<UpdateSparePartSupplierRequest, UpdateSparePartSupplier>()
            .MapWith(src => new UpdateSparePartSupplier(
                Guid.Empty,
                src.SparePartId,
                src.SupplierId,
                src.PurchasePrice,
                src.Principal
            ));
    }
}
