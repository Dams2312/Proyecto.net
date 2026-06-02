using Api.Dtos.SparePart;
using Application.UseCase.SparePart;
using Domain.Entities.SparePart;
using Mapster;

namespace Api.Mappings;

public sealed class SparePartMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // SparePart -> SparePartDto
        config.NewConfig<SparePart, SparePartDto>()
            .Map(dest => dest.Code,
                src => src.Code.Value)
            .Map(dest => dest.Description,
                src => src.Description.Value)
            .Map(dest => dest.PrecioUnitario,
                src => src.PrecioUnitario.Value)
            .Map(dest => dest.StockActual,
                src => src.StockActual.Value)
            .Map(dest => dest.StockMinimo,
                src => src.StockMinimo.Value)
            .Map(dest => dest.CategoryId,
                src => src.CategoryId.Value)
            .Map(dest => dest.UnitId,
                src => src.UnitId.Value)
            .Map(dest => dest.Active,
                src => src.Active.Value);

        // CreateSparePartRequest -> CreateSparePart
        config.NewConfig<CreateSparePartRequest, CreateSparePart>()
            .MapWith(src => new CreateSparePart(
                src.Code,
                src.Description,
                src.PrecioUnitario,
                src.StockActual,
                src.StockMinimo,
                src.CategoryId,
                src.UnitId,
                src.Active
            ));

        // UpdateSparePartRequest -> UpdateSparePart
        config.NewConfig<UpdateSparePartRequest, UpdateSparePart>()
            .MapWith(src => new UpdateSparePart(
                Guid.Empty,
                src.Code,
                src.Description,
                src.PrecioUnitario,
                src.StockActual,
                src.StockMinimo,
                src.CategoryId,
                src.UnitId,
                src.Active
            ));
    }
}
