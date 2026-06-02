using System;
using Api.Dtos.Invoice;
using Application.UseCase.Invoice;
using Domain.Entities.Invoice;
using Mapster;

namespace Api.Mappings;

public sealed class InvoiceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Invoice, InvoiceDto>()
            .Map(dest => dest.OrderId, src => src.OrderId)
            .Map(dest => dest.StatusId, src => src.StatusId)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.PartsCost, src => src.CostoRepuestos.Value)
            .Map(dest => dest.LaborCost, src => src.ManoDeObra.Value)
            .Map(dest => dest.TaxPct, src => src.ImpuestoPct.Value)
            .Map(dest => dest.Discount, src => src.Descuento.Value)
            .Map(dest => dest.Total, src => src.Total.Value);

        config.NewConfig<CreateInvoiceRequest, CreateInvoice>()
            .MapWith(src => new CreateInvoice(
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.PartsCost,
                src.LaborCost,
                src.TaxPct,
                src.Discount,
                src.Total
            ));

        config.NewConfig<UpdateInvoiceRequest, UpdateInvoice>()
            .MapWith(src => new UpdateInvoice(
                Guid.Empty,
                src.OrderId,
                src.StatusId,
                src.UserId,
                src.PartsCost,
                src.LaborCost,
                src.TaxPct,
                src.Discount,
                src.Total
            ));
    }
}
