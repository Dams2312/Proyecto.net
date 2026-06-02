using Api.Dtos.UnitMeasure;
using Application.UseCase.UnitMeasure;
using Domain.Entities.UnitMeasure;
using Mapster;

namespace Api.Mappings;

public sealed class UnitMeasureMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // UnitMeasure -> UnitMeasureDto
        config.NewConfig<UnitMeasure, UnitMeasureDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Abbreviation,
                src => src.Abbreviation.Value);

        // CreateUnitMeasureRequest -> CreateUnitMeasure
        config.NewConfig<CreateUnitMeasureRequest, CreateUnitMeasure>()
            .MapWith(src => new CreateUnitMeasure(
                src.Name,
                src.Abbreviation
            ));

        // UpdateUnitMeasureRequest -> UpdateUnitMeasure
        config.NewConfig<UpdateUnitMeasureRequest, UpdateUnitMeasure>()
            .MapWith(src => new UpdateUnitMeasure(
                Guid.Empty,
                src.Name,
                src.Abbreviation
            ));
    }
}
