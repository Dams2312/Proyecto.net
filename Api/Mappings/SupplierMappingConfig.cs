using Api.Dtos.Supplier;
using Application.UseCase.Supplier;
using Domain.Entities.Supplier;
using Mapster;

namespace Api.Mappings;

public sealed class SupplierMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Supplier -> SupplierDto
        config.NewConfig<Supplier, SupplierDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Nit,
                src => src.Nit.Value)
            .Map(dest => dest.Email,
                src => src.Email.Value)
            .Map(dest => dest.Phone,
                src => src.Phone.Value)
            .Map(dest => dest.Active,
                src => src.Active.Value);

        // CreateSupplierRequest -> CreateSupplier
        config.NewConfig<CreateSupplierRequest, CreateSupplier>()
            .MapWith(src => new CreateSupplier(
                src.Name,
                src.Nit,
                src.Email,
                src.Phone,
                src.CityId,
                src.Active
            ));

        // UpdateSupplierRequest -> UpdateSupplier
        config.NewConfig<UpdateSupplierRequest, UpdateSupplier>()
            .MapWith(src => new UpdateSupplier(
                Guid.Empty,
                src.Name,
                src.Nit,
                src.Email,
                src.Phone,
                src.CityId,
                src.Active
            ));
    }
}
