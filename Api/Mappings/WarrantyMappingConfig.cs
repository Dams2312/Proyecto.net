using System;
using Api.Dtos.Warranty;
using Application.UseCase.Warranty;
using Domain.Entities.Warranty;
using Mapster;

namespace Api.Mappings;

public sealed class WarrantyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Warranty, WarrantyDto>()
            .Map(dest => dest.StartDate, src => src.FechaInicio.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.EndDate, src => src.FechaVencimiento.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.Status, src => src.Estado.Value)
            .Map(dest => dest.Conditions, src => src.Condiciones != null ? src.Condiciones.Value : null);

        config.NewConfig<CreateWarrantyRequest, CreateWarranty>()
            .MapWith(src => new CreateWarranty(
                src.StartDate,
                src.EndDate,
                src.Status,
                src.Conditions
            ));

        config.NewConfig<UpdateWarrantyRequest, UpdateWarranty>()
            .MapWith(src => new UpdateWarranty(
                Guid.Empty,
                src.StartDate,
                src.EndDate,
                src.Status,
                src.Conditions
            ));
    }
}
