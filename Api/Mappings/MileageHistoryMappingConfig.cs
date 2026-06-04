using System;
using Api.Dtos.MileageHistory;
using Application.UseCase.MileageHistory;
using Domain.Entities.MileageHistory;
using Mapster;

namespace Api.Mappings;

public sealed class MileageHistoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MileageHistory, MileageHistoryDto>()
            .Map(dest => dest.VehicleId, src => src.VehicleId.Value)
            .Map(dest => dest.Mileage, src => src.Kilometraje.Value)
            .Map(dest => dest.Date, src => src.Date.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.Source, src => src.Source.Value);

        config.NewConfig<CreateMileageHistoryRequest, CreateMileageHistory>()
            .MapWith(src => new CreateMileageHistory(
                src.VehicleId,
                src.Mileage,
                DateOnly.FromDateTime(src.Date),
                src.Source
            ));

        config.NewConfig<UpdateMileageHistoryRequest, UpdateMileageHistory>()
            .MapWith(src => new UpdateMileageHistory(
                Guid.Empty,
                src.VehicleId,
                src.Mileage,
                src.Date,
                src.Source
            ));
    }
}
