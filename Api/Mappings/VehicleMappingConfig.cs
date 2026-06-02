using Api.Dtos.Vehicle;
using Application.UseCase.Vehicle;
using Domain.Entities.Vehicle;
using Mapster;

namespace Api.Mappings;

public sealed class VehicleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Vehicle -> VehicleDto
        config.NewConfig<Vehicle, VehicleDto>()
            .Map(dest => dest.Vin,
                src => src.Vin.Value)
            .Map(dest => dest.Plate,
                src => src.Plate.Value)
            .Map(dest => dest.Year,
                src => src.Year.Value)
            .Map(dest => dest.Color,
                src => src.Color.Value)
            .Map(dest => dest.Active,
                src => src.Active.Value);

        // CreateVehicleRequest -> CreateVehicle
        config.NewConfig<CreateVehicleRequest, CreateVehicle>()
            .MapWith(src => new CreateVehicle(
                src.ClientId,
                src.ModelId,
                src.Vin,
                src.Plate,
                src.Year,
                src.Color,
                src.Active
            ));

        // UpdateVehicleRequest -> UpdateVehicle
        config.NewConfig<UpdateVehicleRequest, UpdateVehicle>()
            .MapWith(src => new UpdateVehicle(
                Guid.Empty,
                src.ClientId,
                src.ModelId,
                src.Vin,
                src.Plate,
                src.Year,
                src.Color,
                src.Active
            ));
    }
}
