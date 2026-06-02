using System;
using Api.Dtos.InvoiceStatus;
using Application.UseCase.InvoiceStatus;
using Domain.Entities.InvoiceStatus;
using Mapster;

namespace Api.Mappings;

public sealed class InvoiceStatusMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InvoiceStatus, InvoiceStatusDto>()
            .Map(dest => dest.Name, src => src.Name.Value);

        config.NewConfig<CreateInvoiceStatusRequest, CreateInvoiceStatus>()
            .MapWith(src => new CreateInvoiceStatus(
                src.Name
            ));

        config.NewConfig<UpdateInvoiceStatusRequest, UpdateInvoiceStatus>()
            .MapWith(src => new UpdateInvoiceStatus(
                Guid.Empty,
                src.Name
            ));
    }
}
