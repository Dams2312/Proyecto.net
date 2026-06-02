using Api.Dtos.VehicleModel;
using Application.UseCase.VehicleModel;
using Domain.Entities.Vehiclemodel;
using Mapster;

namespace Api.Mappings;

public sealed class VehicleModelMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // VehicleModel -> VehicleModelDto
        config.NewConfig<VehicleModel, VehicleModelDto>()
            .Map(dest => dest.BrandId,
                src => src.BrandId.Value)
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.YearFrom,
                src => src.YearFrom != null ? src.YearFrom.Value : null)
            .Map(dest => dest.YearTo,
                src => src.YearTo != null ? src.YearTo.Value : null);

        // CreateVehicleModelRequest -> CreateVehicleModel
        config.NewConfig<CreateVehicleModelRequest, CreateVehicleModel>()
            .MapWith(src => new CreateVehicleModel(
                src.BrandId,
                src.Name,
                src.YearFrom,
                src.YearTo
            ));

        // UpdateVehicleModelRequest -> UpdateVehicleModel
        config.NewConfig<UpdateVehicleModelRequest, UpdateVehicleModel>()
            .MapWith(src => new UpdateVehicleModel(
                Guid.Empty,
                src.BrandId,
                src.Name,
                src.YearFrom,
                src.YearTo
            ));
    }
}
