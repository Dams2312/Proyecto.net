using System;
using Api.Dtos.CustomerEmail;
using Application.UseCase.CustomerEmail;
using Domain.Entities.CustomerEmails;
using Domain.ValueObject.CustomerEmail;
using Mapster;

namespace Api.Mappings;

public sealed class CustomerEmailMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerEmail, CustomerEmailDto>()
            .Map(dest => dest.Email, src => src.Address.Value)
            .Map(dest => dest.Principal, src => src.Primary.Value);

        config.NewConfig<CreateCustomerEmailRequest, CreateCustomerEmail>()
            .MapWith(src => new CreateCustomerEmail(
                src.CustomerId,
                src.Email,
                src.Principal
            ));

        config.NewConfig<UpdateCustomerEmailRequest, UpdateCustomerEmail>()
            .MapWith(src => new UpdateCustomerEmail(
                src.Id,
                src.CustomerId,
                src.Email,
                src.Principal
            ));
    }
}