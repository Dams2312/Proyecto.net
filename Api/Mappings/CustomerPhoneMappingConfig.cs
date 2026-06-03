using System;
using Api.Dtos.CustomerPhone;
using Application.UseCase.CustomerPhone;
using Domain.Entities.CustomerPhones;
using Domain.ValueObject.CustomerPhone;
using Mapster;

namespace Api.Mappings;

public sealed class CustomerPhoneMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerPhone, CustomerPhoneDto>()
            .Map(dest => dest.Phone, src => src.PhoneNumber.Value)
            .Map(dest => dest.Type, src => src.PhoneType.Value);

        config.NewConfig<CreateCustomerPhoneRequest, CreateCustomerPhone>()
            .MapWith(src => new CreateCustomerPhone(
                src.Phone,
                src.Type,
                Guid.Empty
            ));

        config.NewConfig<UpdateCustomerPhoneRequest, UpdateCustomerPhone>()
            .MapWith(src => new UpdateCustomerPhone(
                src.Id,
                src.Phone,
                src.Type,
                Guid.Empty
            ));
    }
}