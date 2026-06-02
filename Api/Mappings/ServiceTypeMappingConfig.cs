using Api.Dtos.ServiceType;
using Application.UseCase.ServiceType;
using Domain.Entities.ServiceType;
using Mapster;

namespace Api.Mappings;

public sealed class ServiceTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // ServiceType -> ServiceTypeDto
        config.NewConfig<ServiceType, ServiceTypeDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Description,
                src => src.Description.Value)
            .Map(dest => dest.EstimatedDays,
                src => src.EstimatedDays.Value);

        // CreateServiceTypeRequest -> CreateServiceType
        config.NewConfig<CreateServiceTypeRequest, CreateServiceType>()
            .MapWith(src => new CreateServiceType(
                src.Name,
                src.Description,
                src.EstimatedDays
            ));

        // UpdateServiceTypeRequest -> UpdateServiceType
        config.NewConfig<UpdateServiceTypeRequest, UpdateServiceType>()
            .MapWith(src => new UpdateServiceType(
                Guid.Empty,
                src.Name,
                src.Description,
                src.EstimatedDays
            ));
    }
}
