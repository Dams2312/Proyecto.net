using System;
using Api.Dtos.Contries;
using Application.UseCase.Countries;
using Domain.Entities.Countries;
using Mapster;

namespace Api.Mappings;

public sealed class CountryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Country, CountryDto>()
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Code, src => src.Code.Value);

        config.NewConfig<CreateCountryRequest, CreateCountry>()
            .MapWith(src => new CreateCountry(
                src.Name,
                src.Code
            ));

        config.NewConfig<UpdateCountryRequest, UpdateCountry>()
            .MapWith(src => new UpdateCountry(
                Guid.Empty,
                src.Name,
                src.Code
            ));
    }
}
