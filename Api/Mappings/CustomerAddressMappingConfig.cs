using System;
using Api.Dtos.CustomerAddress;
using Application.UseCase.CustomerAddress;
using Domain.Entities.CustomerAddresses;
using Domain.ValueObject.CustomerAddress;
using Mapster;

namespace Api.Mappings;

public sealed class CustomerAddressMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerAddress, CustomerAddressDto>()
            .Map(dest => dest.Street, src => src.Street.Value)
            .Map(dest => dest.Principal, src => src.Primary.Value);

        config.NewConfig<CreateCustomerAddressRequest, CreateCustomerAddress>()
            .MapWith(src => new CreateCustomerAddress(
                src.CustomerId,
                src.CityId,
                src.Street,
                src.Principal
            ));

        config.NewConfig<UpdateCustomerAddressRequest, UpdateCustomerAddress>()
            .MapWith(src => new UpdateCustomerAddress(
                src.Id,
                src.CustomerId,
                src.CityId,
                src.Street,
                src.Principal
            ));
    }
}