using Api.Dtos.VehicleMake;
using Application.UseCase.VehicleMake;
using Domain.Entities.VehicleMake;
using Mapster;

namespace Api.Mappings;

public sealed class VehicleMakeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // VehicleMake -> VehicleMakeDto
        config.NewConfig<VehicleMake, VehicleMakeDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value);

        // CreateVehicleMakeRequest -> CreateVehicleMake
        config.NewConfig<CreateVehicleMakeRequest, CreateVehicleMake>()
            .MapWith(src => new CreateVehicleMake(
                src.Name
            ));

        // UpdateVehicleMakeRequest -> UpdateVehicleMake
        config.NewConfig<UpdateVehicleMakeRequest, UpdateVehicleMake>()
            .MapWith(src => new UpdateVehicleMake(
                Guid.Empty,
                src.Name
            ));
    }
}
