using Api.Dtos.SpareCategory;
using Application.UseCase.SpareCategory;
using Domain.Entities.SpareCategory;
using Mapster;

namespace Api.Mappings;

public sealed class SpareCategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // SpareCategory -> SpareCategoryDto
        config.NewConfig<SpareCategory, SpareCategoryDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Description,
                src => src.Description.Value);

        // CreateSpareCategoryRequest -> CreateSpareCategory
        config.NewConfig<CreateSpareCategoryRequest, CreateSpareCategory>()
            .MapWith(src => new CreateSpareCategory(
                src.Name,
                src.Description
            ));

        // UpdateSpareCategoryRequest -> UpdateSpareCategory
        config.NewConfig<UpdateSpareCategoryRequest, UpdateSpareCategory>()
            .MapWith(src => new UpdateSpareCategory(
                Guid.Empty,
                src.Name,
                src.Description
            ));
    }
}
