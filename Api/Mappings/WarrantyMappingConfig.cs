using Api.Dtos.Warranty;
using Application.UseCase.Warranty;
using Domain.Entities.Warranty;
using Mapster;

namespace Api.Mappings;

public sealed class WarrantyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Warranty -> WarrantyDto
        config.NewConfig<Warranty, WarrantyDto>()
            .Map(dest => dest.FechaInicio,
                src => src.FechaInicio.Value)
            .Map(dest => dest.FechaVencimiento,
                src => src.FechaVencimiento.Value)
            .Map(dest => dest.Estado,
                src => src.Estado.Value)
            .Map(dest => dest.Condiciones,
                src => src.Condiciones != null ? src.Condiciones.Value : null);

        // CreateWarrantyRequest -> CreateWarranty
        config.NewConfig<CreateWarrantyRequest, CreateWarranty>()
            .MapWith(src => new CreateWarranty(
                src.OrderId,
                src.ServiceTypeId,
                src.MechanicId,
                src.FechaInicio,
                src.FechaVencimiento,
                src.Estado,
                src.Condiciones
            ));

        // UpdateWarrantyRequest -> UpdateWarranty
        config.NewConfig<UpdateWarrantyRequest, UpdateWarranty>()
            .MapWith(src => new UpdateWarranty(
                Guid.Empty,
                src.OrderId,
                src.ServiceTypeId,
                src.MechanicId,
                src.FechaInicio,
                src.FechaVencimiento,
                src.Estado,
                src.Condiciones
            ));
    }
}
