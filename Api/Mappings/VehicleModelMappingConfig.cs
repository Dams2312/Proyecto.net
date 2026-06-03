using System;
using Api.Dtos.VehicleModel;
using Application.UseCase.VehicleModel;
using Domain.Entities.Vehiclemodel;
using Mapster;

namespace Api.Mappings;

public sealed class VehicleModelMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<VehicleModel, VehicleModelDto>()
            .Map(dest => dest.BrandId, src => src.BrandId.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.YearFrom, src => src.YearFrom != null ? src.YearFrom.Value : (int?)null)
            .Map(dest => dest.YearTo, src => src.YearTo != null ? src.YearTo.Value : (int?)null);

        config.NewConfig<CreateVehicleModelRequest, CreateVehicleModel>()
            .MapWith(src => new CreateVehicleModel(
                src.BrandId,
                src.Name,
                src.YearFrom,
                src.YearTo
            ));

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
