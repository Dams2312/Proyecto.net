using System;
using Api.Dtos.Departament;
using Application.UseCase.Departament;
using Domain.Entities.Departments;
using Mapster;

namespace Api.Mappings;

public sealed class DepartmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Department, DepartmentDto>()
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Code, src => src.Code.Value);

        config.NewConfig<CreateDepartmentRequest, CreateDepartment>()
            .MapWith(src => new CreateDepartment(
                src.Code,
                src.Name,
                src.CountryId
            ));

        config.NewConfig<UpdateDepartmentRequest, UpdateDepartment>()
            .MapWith(src => new UpdateDepartment(
                Guid.Empty,
                src.Code,
                src.Name,
                src.CountryId
            ));
    }
}
