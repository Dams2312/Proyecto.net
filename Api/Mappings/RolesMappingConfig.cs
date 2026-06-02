using Api.Dtos.Roles;
using Application.UseCase.Roles;
using Domain.Entities.Roles;
using Mapster;

namespace Api.Mappings;

public sealed class RolesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Role -> RoleDto
        config.NewConfig<Role, RoleDto>()
            .Map(dest => dest.Name,
                src => src.Name.Value)
            .Map(dest => dest.Description,
                src => src.Description.Value);

        // CreateRoleRequest -> CreateRole
        config.NewConfig<CreateRoleRequest, CreateRole>()
            .MapWith(src => new CreateRole(
                src.Name,
                src.Description
            ));

        // UpdateRoleRequest -> UpdateRole
        config.NewConfig<UpdateRoleRequest, UpdateRole>()
            .MapWith(src => new UpdateRole(
                Guid.Empty,
                src.Name,
                src.Description
            ));
    }
}
