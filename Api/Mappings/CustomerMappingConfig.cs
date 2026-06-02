using System;
using Api.Dtos.Customer;
using Application.UseCase.Customers;
using Domain.Entities.Customers;
using Mapster;

namespace Api.Mappings;

public sealed class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDto>()
            .Map(dest => dest.Names, src => src.Names.Value)
            .Map(dest => dest.LastNames, src => src.Surnames.Value);

        config.NewConfig<CreateCustomerRequest, CreateCustomer>()
            .MapWith(src => new CreateCustomer(
                src.Names,
                src.LastNames,
                src.DocumentNumber,
                src.DocumentType,
                true
            ));

        config.NewConfig<UpdateCustomerRequest, UpdateCustomer>()
            .MapWith(src => new UpdateCustomer(
                Guid.Empty,
                src.Names,
                src.LastNames,
                string.Empty,
                string.Empty,
                src.Active
            ));
    }
}
