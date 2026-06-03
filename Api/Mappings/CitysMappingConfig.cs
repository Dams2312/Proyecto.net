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
        config.NewConfig<City, CitysDto>()
            .Map(dest => dest.CountryId, src => src.DepartmentId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Code, src => src.Code);

        config.NewConfig<CreateCitysRequest, CreateCity>()
            .MapWith(src => new CreateCity(
                src.Name,
                src.CountryId,
                src.Code
            ));

        config.NewConfig<UpdateCitysRequest, UpdateCity>()
            .MapWith(src => new UpdateCity(
                Guid.Empty,
                src.CountryId,
                src.Name,
                src.Code
            ));
    }
}