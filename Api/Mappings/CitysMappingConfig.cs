using System;
using Api.Dtos.Citys;
using Application.UseCase.Citys;
using Domain.Entities.Citys;
using Mapster;

namespace Api.Mappings;

public sealed class CitysMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Citys, CitysDto>()
            .Map(dest => dest.CountryId, src => src.CountryId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Code, src => src.Code);

        config.NewConfig<CreateCitysRequest, CreateCitys>()
            .MapWith(src => new CreateCitys(
                src.Name,
                src.CountryId,
                src.Code
            ));

        config.NewConfig<UpdateCitysRequest, UpdateCitys>()
            .MapWith(src => new UpdateCitys(
                Guid.Empty,
                src.CountryId,
                src.Name,
                src.Code
            ));
    }
}
