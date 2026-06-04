using System;
using Api.Dtos.Users;
using Application.UseCase.Users;
using Domain.Entities.Users;
using Mapster;

namespace Api.Mappings;

public sealed class UsersMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(dest => dest.Email, src => src.Mail.Value)
            .Map(dest => dest.Names, src => src.Names.Value)
            .Map(dest => dest.LastNames, src => src.Surnames.Value)
            .Map(dest => dest.Active, src => src.Active.Value)
            .Map(dest => dest.CreatedAt, src => src.CreateDate.Value)
            .Map(dest => dest.RoleId, src => src.RoleId.Value); 

            

        config.NewConfig<CreateUserRequest, CreateUser>()
            .MapWith(src => new CreateUser(
                src.RoleId,
                src.Email,
                src.Password,
                src.Names,
                src.LastNames
            ));

        config.NewConfig<UpdateUserRequest, UpdateUser>()
            .MapWith(src => new UpdateUser(
                Guid.Empty,
                src.RoleId,
                src.Email,
                src.Names,
                src.LastNames,
                src.Active
            ));
    }
}
